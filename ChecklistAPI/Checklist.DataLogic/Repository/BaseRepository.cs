using Checklist.DataLogic.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository
{
    public class BaseRepository<T>: IBaseRepository<T> where T: class
    {
        protected IDbConnection Connection;
        protected DefaultContext _context;
        private readonly string _name;
        private readonly ISqlQueries _sqlQueries;

        public BaseRepository(DefaultContext context, IDbConnection connection, ISqlQueries sqlQueries, string name)
        {
            _context = context;
            _name = name;
            _sqlQueries = sqlQueries;
            Connection = connection;
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public BaseRepository(DefaultContext context)
        {
            _context = context;
        }

        public virtual async Task Create(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }

        public string GetSqlQuery([CallerMemberName]string methodName = "",  string email ="", int? paramId = null)
        {
            string key = $"{_name}.{methodName}"
                .Replace("Async", string.Empty).ToLower();

            if (paramId.HasValue)
            {
                return _sqlQueries[key].Replace("@__userId_0", paramId.ToString());
            }
            if (email.Length > 0)
            {
                return _sqlQueries[key].Replace("@__email_0", email);
            }
            return _sqlQueries[key];
        }
    }
}
