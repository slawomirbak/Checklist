using Checklist.DataLogic.Entities;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task Create(User entity);

        Task<bool> IsEmailExist(string email);
        Task<User> GetByEmial(string email);
    }
}
