using Checklist.DataLogic.Repository.DashboardRepository;
using Checklist.DataLogic.Repository.UserRepository;
using System;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private DefaultContext _context;

        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        private IUserRepository _userRepository;
        public IUserRepository userRepository => _userRepository ?? (_userRepository = new UserRepository.UserRepository(_context));

        private IDashboardRepository _dashoardRepository;
        public IDashboardRepository dashboardRepository => _dashoardRepository ?? (_dashoardRepository = new DashboardRepository.DashboardRepository(_context));


        public async Task Save()
        {
             await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
