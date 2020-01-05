using Checklist.DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.DashboardRepository
{
    public class DashboardRepository : BaseRepository<UserChecklist>, IDashboardRepository
    {
        public DashboardRepository(DefaultContext context): base(context)
        {
        }

        public async Task<List<UserChecklist>> GetLists(int userId)
        {
            var userChecklist = await _context.UserChecklists.Where(cl => cl.User.Id == userId).Include(cl => cl.Fields).ToListAsync();

            return userChecklist;
        }
    }
}
