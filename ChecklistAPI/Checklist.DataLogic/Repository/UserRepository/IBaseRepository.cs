using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.UserRepository
{
    public interface IBaseRepository<T> where T: class
    {
        Task Create(T entity);
    }
}