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

        public bool Add(Crypto entity)
        {
            if (_cryptoContext.Cryptos.Contains(entity) || _cryptoContext.Cryptos.FirstOrDefault(s => s.Id == entity.Id) != null)
                return false;
            _cryptoContext.Cryptos.Add(new Crypto { Name = entity.Name, Price = entity.Price, IsToken = entity.IsToken});
            _cryptoContext.SaveChanges();
            return true;
        }

        public IEnumerable<Crypto> Get()
        {
            return _cryptoContext.Cryptos.AsEnumerable().OrderBy(s => s.Name);
        }

        public Crypto? Get(int id)
        {
            return _cryptoContext.Cryptos.FirstOrDefault(s => s.Id == id);
        }

        public bool Update(Crypto entity)
        {
            if (entity == null)
                return false;
            var item = _cryptoContext.Cryptos.FirstOrDefault(s => s.Id == entity.Id);
            if (item == null)
                return false;
            item.Name = entity.Name;
            item.Price = entity.Price;
            item.IsToken = entity.IsToken;
            _cryptoContext.Cryptos.Update(item);
            _cryptoContext.SaveChanges();
            return true;
        }
        public bool Delete(Crypto entity)
        {
            var item = _cryptoContext.Cryptos.FirstOrDefault(s => s.Id == entity.Id);
            if (item == null)
                return false;
            _cryptoContext.Cryptos.Remove(item);
            _cryptoContext.SaveChanges();
            return true;
        }
    }
}
