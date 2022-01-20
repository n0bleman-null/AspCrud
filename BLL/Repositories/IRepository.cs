using System.Collections.Generic;

namespace BLL.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T? Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);        
    }
}
