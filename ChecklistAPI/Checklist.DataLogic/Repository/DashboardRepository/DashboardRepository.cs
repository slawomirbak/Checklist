using Checklist.DataLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Repository.DashboardRepository
{
    public class DashboardRepository : BaseRepository<UserChecklist>, IDashboardRepository
    {
        public DashboardRepository(DefaultContext context): base(context)
        {
        }

        
    }
}
