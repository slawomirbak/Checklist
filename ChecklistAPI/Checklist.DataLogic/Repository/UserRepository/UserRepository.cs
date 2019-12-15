using Checklist.DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DefaultContext context) : base(context)
        {
        }

        public async Task<bool> GetByEmail(string email)
        {
            return  await _context.Users.AnyAsync(u => u.Email == email.Trim());
        }
    }
}
