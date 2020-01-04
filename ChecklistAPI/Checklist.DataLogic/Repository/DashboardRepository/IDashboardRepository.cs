using Checklist.DataLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.DashboardRepository
{
    public interface IDashboardRepository
    {
        Task Create(UserChecklist entity);
    }
}
