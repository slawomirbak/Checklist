using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Checklist.Abstract.Validation;
using Checklist.DataLogic.Entities;
using Checklist.DataLogic.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Services.Services.DashboardService
{
    public class DashboardService : ServiceBase, IDashboardService
    {
        private readonly IConfiguration _configuration;

        public DashboardService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork, mapper)
        {
            _configuration = configuration;
        }

        public async Task<BasePlainResponse> Add(UserChecklistDto checklistDto, string userEmail)
        {
            var plainResponse = new BasePlainResponse();
            var checklist = _mapper.Map<UserChecklist>(checklistDto);

            var user = await _unitOfWork.userRepository.GetByEmail(userEmail);
            checklist.User = user;
            checklist.CreatedDate = DateTime.UtcNow;
            await _unitOfWork.dashboardRepository.Create(checklist);
            await _unitOfWork.Save();

            return plainResponse;
        }

        public async Task<ChecklistPlainResponse> GetLists(string userEmail)
        {
            var checklistReponse = new ChecklistPlainResponse();
            var user = await _unitOfWork.userRepository.GetByEmail(userEmail);

            var userChecklists =  await _unitOfWork.dashboardRepository.GetLists(user.Id);
            foreach (var userChecklist in userChecklists)
            {
                checklistReponse.Data.Add(_mapper.Map<UserChecklistDto>(userChecklist));
            }
            
            return checklistReponse;
        }

        public async Task<BasePlainResponse> UploadImage(IFormFile file,int checklistId, string userEmail)
        {
            var checklistNotBelongToUserResponse = await DoesUserChecklistBelongToUser(checklistId, userEmail);
            if (!checklistNotBelongToUserResponse.IsSuccessful)
            {
                return checklistNotBelongToUserResponse;
            }

            var checklistReponse = new BasePlainResponse();
            var fileName = Guid.NewGuid() + file.FileName;
            var imageUloadedResponse =  await UploadImage(file, fileName);

            if (!imageUloadedResponse.IsSuccessful)
            {
                return imageUloadedResponse;
            }
            await _unitOfWork.dashboardRepository.AddUserChecklistImage(checklistId, fileName);
            await _unitOfWork.Save();
            return checklistReponse;
        }
        public async Task<BasePlainResponse> Update(UserChecklistDto userChecklistDto, string userEmail)
        {
            var checklistNotBelongToUserResponse = await DoesUserChecklistBelongToUser(userChecklistDto.Id, userEmail);
            if (!checklistNotBelongToUserResponse.IsSuccessful)
            {
                return checklistNotBelongToUserResponse;
            }

            var checklistReponse = new BasePlainResponse();
            _unitOfWork.dashboardRepository.Update(_mapper.Map<UserChecklist>(userChecklistDto));
            await _unitOfWork.Save(); 
            return checklistReponse;
        }

        public async Task<BasePlainResponse> Delete(int userChecklitId, string userEmail)
        {
            var checklistNotBelongToUserResponse = await DoesUserChecklistBelongToUser(userChecklitId, userEmail);
            if (!checklistNotBelongToUserResponse.IsSuccessful)
            {
                return checklistNotBelongToUserResponse;
            }
            var checklistReponse = new BasePlainResponse();
            var checklist = await _unitOfWork.dashboardRepository.GetListById(userChecklitId);
            foreach(var image in checklist.ChecklistImages)
            {
                await DeleteImage(image.Name);
            }
            await _unitOfWork.dashboardRepository.Delete(userChecklitId);
            await _unitOfWork.Save();

            return checklistReponse;
        }

        public async Task DeleteImage(string imageName)
        {
            var client = new AmazonS3Client(_configuration.GetSection("AmazonS3:accessKey").Value, _configuration.GetSection("AmazonS3:accessSecret").Value, Amazon.RegionEndpoint.EUCentral1);

            var request = new DeleteObjectRequest
            {
                BucketName = _configuration.GetSection("AmazonS3:bucket").Value,
                Key = imageName
            };
            await client.DeleteObjectAsync(request);
        }

        private async Task<BasePlainResponse> UploadImage(IFormFile file, string fileName)
        {
            var checklistReponse = new BasePlainResponse();
            var client = new AmazonS3Client(_configuration.GetSection("AmazonS3:accessKey").Value, _configuration.GetSection("AmazonS3:accessSecret").Value, Amazon.RegionEndpoint.EUCentral1);

            byte[] fileBytes = new Byte[file.Length];
            file.OpenReadStream().Read(fileBytes, 0, Int32.Parse(file.Length.ToString()));

            PutObjectResponse response = null;
            using (var stream = new MemoryStream(fileBytes))
            {
                var request = new PutObjectRequest
                {
                    BucketName = _configuration.GetSection("AmazonS3:bucket").Value,
                    Key = fileName,
                    InputStream = stream,
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };

                response = await client.PutObjectAsync(request);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    return checklistReponse;
                }
                else
                {
                    checklistReponse.IsSuccessful = false;
                    checklistReponse.ErrorMessage = "Something went wrong when saving images.";
                    return checklistReponse;
                }
            }
        }

        private async Task<BasePlainResponse> DoesUserChecklistBelongToUser(int checklistId, string userEmail)
        {
            var checklistReponse = new BasePlainResponse();
            var isUserChecklist = await _unitOfWork.dashboardRepository.DoesChecklistBelongToUser(checklistId, userEmail);
            if (!isUserChecklist)
            {
                checklistReponse.IsSuccessful = false;
                checklistReponse.ErrorMessage = "This checklist doesn't belong to this user";
                return checklistReponse;
            }
            return checklistReponse;
        }
    }
}
