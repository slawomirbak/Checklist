using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Checklist.DataLogic.Repository.UnitOfWork;
using System.Threading.Tasks;

namespace Checklist.Services.Services.UserService
{
    public class UserService: ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Add(UserDto userDto)
        {
            await _unitOfWork.userRepository.Create(new DataLogic.Entities.User());
            await _unitOfWork.Save();
        }
    }
}
