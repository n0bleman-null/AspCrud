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
        public Task AddAsync(Crypto entity)
        {
            return _cryptoContext.Cryptos.AddAsync(new Crypto { Name = entity.Name, Price = entity.Price, IsToken = entity.IsToken}).AsTask();
        }
        public void Update(Crypto entity)
        {
            _cryptoContext.Cryptos.Update(entity);
        }
        public void Delete(Crypto entity)
        {
            _cryptoContext.Cryptos.Remove(entity);
        }
    }
}
