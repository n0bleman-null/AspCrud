using System.Collections.Generic;

namespace AspCrud.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T? Get(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        
    }
}
