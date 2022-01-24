using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICryptoService
    {
        Task<IQueryable<Crypto>> GetAsync();
        Task AddAsync(Crypto crypto);
        Task UpdateAsync(Crypto crypto);
        Task DeleteAsync(Crypto crypto);
    }
}
