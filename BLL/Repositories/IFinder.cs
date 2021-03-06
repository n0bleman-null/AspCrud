using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IFinder<T> where T : class
    {
        Task<IQueryable<T>> AsQueryableAsync();
    }
}
