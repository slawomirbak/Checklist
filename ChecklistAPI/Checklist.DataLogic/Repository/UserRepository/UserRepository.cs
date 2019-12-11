using Checklist.DataLogic.Entities;

namespace Checklist.DataLogic.Repository.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DefaultContext context) : base(context)
        {
        }
    }
}
