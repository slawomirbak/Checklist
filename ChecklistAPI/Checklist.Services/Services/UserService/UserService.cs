using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Checklist.Abstract.Validation;
using Checklist.DataLogic.Entities;
using Checklist.DataLogic.Repository.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace Checklist.Services.Services.UserService
{
    public class UserService: ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BasePlainResponse> Add(UserDto userDto)
        {
            var plainResponse = new BasePlainResponse();
            var user = _mapper.Map<User>(userDto);
            var doesUserExist = await _unitOfWork.userRepository.GetByEmail(user.Email);

            if (doesUserExist)
            {
                plainResponse.IsSuccessful = false;
                plainResponse.ErrorMessage = "The e-mail address already exists in database";
                return plainResponse;
            }
            user.CreatedDate = DateTime.UtcNow;
            user.PasswordHash(userDto.Password);

            await _unitOfWork.userRepository.Create(user);
            await _unitOfWork.Save();

            return plainResponse;
        }
    }
}
