using AspCrud.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspCrud.Repositories
{
    public class CryptoRepository : IRepository<Crypto>
    {
        public CryptoRepository()
        {
            _cryptoStorage.Add(new Crypto { Id = 1, Name = "BTC", Price = 20001, IsToken = false});
            _cryptoStorage.Add(new Crypto { Id = 2, Name = "ETH", Price = 4900, IsToken = false});
            _cryptoStorage.Add(new Crypto { Id = 3, Name = "USDT", Price = 1, IsToken = false});
            _cryptoStorage.Add(new Crypto { Id = 5, Name = "NFT", Price = 5, IsToken = true});
        }
        public List<Crypto> _cryptoStorage = new List<Crypto>();

        public bool Add(Crypto entity)
        {
            if (_cryptoStorage.Contains(entity) || _cryptoStorage.Find(s => s.Id == entity.Id) != null)
                return false;
            _cryptoStorage.Add(entity);
            return true;
        }       

        public IEnumerable<Crypto> Get()
        {
            return _cryptoStorage.OrderBy(s => s.Name);
        }

        public Crypto? Get(int id)
        {
            return _cryptoStorage.FirstOrDefault(s => s.Id == id);
        }

        public bool Update(Crypto entity)
        {
            if (entity == null)
                return false;
            var item = _cryptoStorage.Find(s => s.Id == entity.Id);
            if (item == null)
                return false;
            item.Name = entity.Name;
            item.Price = entity.Price;
            item.IsToken = entity.IsToken;
            return true;
        }
        public bool Delete(Crypto entity)
        {
            if (!_cryptoStorage.Contains(entity))
                return false;
            _cryptoStorage.Remove(entity);
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _cryptoStorage.Find(s => s.Id == id);
            if (entity == null)
                return false;
            _cryptoStorage.Remove(entity);
            return true;
        }
    }
}
