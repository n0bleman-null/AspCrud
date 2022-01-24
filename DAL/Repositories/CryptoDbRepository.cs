using BLL.Entities;
using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class CryptoDbRepository : ICryptoRepository // can make abstract
    {
        private readonly CryptoContext _cryptoContext;

        public abstract event CryptoEventHandler? CryptoChanged;

        public CryptoDbRepository(CryptoContext cryptoContext)
        {
            _cryptoContext = cryptoContext;
        }
        public virtual Task AddAsync(Crypto entity)
        {
            return _cryptoContext.Cryptos.AddAsync(new Crypto {Name = entity.Name, Price = entity.Price, IsToken = entity.IsToken}).AsTask();
        }
        public virtual void Update(Crypto entity)
        {
            _cryptoContext.Cryptos.Update(entity);
        }
        public virtual void Delete(Crypto entity)
        {
            _cryptoContext.Cryptos.Remove(entity);
        }
    }
}
