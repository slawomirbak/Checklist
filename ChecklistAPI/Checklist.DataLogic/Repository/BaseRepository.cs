using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository
{
    public class BaseRepository<T>: IBaseRepository<T> where T: class
    {
        protected DefaultContext _context;

        public BaseRepository(DefaultContext context)
        {
            _context = context;
        }
        public virtual async Task Create(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }
    }
}
