using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
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

        public async Task Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.CreatedDate = DateTime.UtcNow;
            user.PasswordHash(userDto.Password);

            await _unitOfWork.userRepository.Create(user);
            await _unitOfWork.Save();
        }
    }
}
