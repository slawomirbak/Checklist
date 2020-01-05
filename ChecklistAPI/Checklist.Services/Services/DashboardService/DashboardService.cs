using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Checklist.Abstract.Validation;
using Checklist.DataLogic.Entities;
using Checklist.DataLogic.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Services.Services.DashboardService
{
    public class DashboardService : ServiceBase, IDashboardService
    {
        public DashboardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BasePlainResponse> Add(UserChecklistDto checklistDto, string userEmail)
        {
            var plainResponse = new BasePlainResponse();
            var checklist = _mapper.Map<UserChecklist>(checklistDto);

            var user = await _unitOfWork.userRepository.GetByEmial(userEmail);
            checklist.User = user;
            checklist.CreatedDate = DateTime.UtcNow;
            await _unitOfWork.dashboardRepository.Create(checklist);
            await _unitOfWork.Save();

            return plainResponse;
        }

        public async Task<ChecklistPlainResponse> GetLists(string userEmail)
        {
            var checklistReponse = new ChecklistPlainResponse();
            var user = await _unitOfWork.userRepository.GetByEmial(userEmail);

            var userChecklists =  await _unitOfWork.dashboardRepository.GetLists(user.Id);
            foreach (var userChecklist in userChecklists)
            {
                checklistReponse.Data.Add(_mapper.Map<UserChecklistDto>(userChecklist));
                
            }
            
            return checklistReponse;
        }
    }
}
