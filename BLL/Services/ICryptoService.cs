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
        Task<List<Crypto>> GetAllAsync();
        Task<Crypto?> GetByIdAsync(int id);
        Task<Crypto?> GetByNameAsync(string name);
        Task AddAsync(Crypto crypto);
        Task UpdateAsync(Crypto crypto);
        Task DeleteAsync(Crypto crypto);
    }
}
