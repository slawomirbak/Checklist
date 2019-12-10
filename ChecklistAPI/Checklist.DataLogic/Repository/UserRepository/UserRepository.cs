using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UserRepository
{
    public class UserRepository : BaseRepository<IdentityUser>, IUserRepository
    {
        public UserRepository(DefaultContext context) : base(context)
        {
        }
    }
}
