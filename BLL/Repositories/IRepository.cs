using System.Collections.Generic;

namespace BLL.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T? Get(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        
    }
}
