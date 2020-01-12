using Checklist.DataLogic.Repository.Dapper;
using Checklist.DataLogic.Repository.DashboardRepository;
using Checklist.DataLogic.Repository.UserRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private DefaultContext _context;
        private readonly IConfiguration _configuration;
        private ISqlQueries _sqlQueries;
        private readonly SqlConnection _connection;

        public UnitOfWork(DefaultContext context, IConfiguration configuration, ISqlQueries sqlQueries)
        {
            _context = context;
            _configuration = configuration;
            _sqlQueries = sqlQueries;
            _connection = new SqlConnection(_configuration.GetConnectionString("DbDefault"));
        }

        private IUserRepository _userRepository;
        public IUserRepository userRepository => _userRepository ?? (_userRepository = new UserRepository.UserRepository(_context, _connection, _sqlQueries));


        private IDashboardRepository _dashboardRepository;
        public IDashboardRepository dashboardRepository => _dashboardRepository ?? (_dashboardRepository = new DashboardRepository.DashboardRepository(_context, _connection, _sqlQueries));


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
