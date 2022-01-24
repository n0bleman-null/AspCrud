using System.Collections.Generic;

namespace BLL.Repositories
{
    public interface IRepository<T>
    {        
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);        
    }
}
