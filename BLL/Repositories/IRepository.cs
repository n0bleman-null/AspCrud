using System.Collections.Generic;

namespace BLL.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);        
    }
}
