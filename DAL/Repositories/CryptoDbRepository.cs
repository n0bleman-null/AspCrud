using BLL.Entities;
using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CryptoDbRepository : IRepository<Crypto>
    {
        private readonly CryptoContext _cryptoContext;
        public CryptoDbRepository(CryptoContext cryptoContext)
        {
            _cryptoContext = cryptoContext;
        }
        public async Task AddAsync(Crypto entity)
        {
            await _cryptoContext.Cryptos.AddAsync(new Crypto { Name = entity.Name, Price = entity.Price, IsToken = entity.IsToken});
        }
        public async Task UpdateAsync(Crypto entity)
        {
            await Task.Run(() => _cryptoContext.Cryptos.Update(entity));
        }
        public async Task DeleteAsync(Crypto entity)
        {
           await Task.Run(() => _cryptoContext.Cryptos.Remove(entity));
        }
    }
}
