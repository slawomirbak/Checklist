using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository
{
    public interface IBaseRepository<T> where T: class
    {
        Task Create(T entity);
    }
}
