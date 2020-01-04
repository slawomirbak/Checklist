using Checklist.DataLogic.Repository.DashboardRepository;
using Checklist.DataLogic.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }

        IDashboardRepository dashboardRepository { get; }
        Task Save();
    }
}
