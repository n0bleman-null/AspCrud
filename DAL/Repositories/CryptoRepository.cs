using BLL.Entities;
using BLL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
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

        public void Add(Crypto entity)
        {
            _cryptoStorage.Add(entity);
        }       

        public IEnumerable<Crypto> Get()
        {
            return _cryptoStorage.OrderBy(s => s.Name);
        }

        public Crypto? Get(int id)
        {
            return _cryptoStorage.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Crypto entity)
        {
            var item = _cryptoStorage.Find(s => s.Id == entity.Id);
            item.Name = entity.Name;
            item.Price = entity.Price;
            item.IsToken = entity.IsToken;
        }
        public void Delete(Crypto entity)
        {
            _cryptoStorage.Remove(entity);
        }
    }
}
