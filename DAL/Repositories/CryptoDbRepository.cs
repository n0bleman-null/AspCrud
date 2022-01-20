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

        public void Add(Crypto entity)
        {
            _cryptoContext.Cryptos.Add(new Crypto { Name = entity.Name, Price = entity.Price, IsToken = entity.IsToken});
            _cryptoContext.SaveChanges();
        }

        public IEnumerable<Crypto> Get()
        {
            return _cryptoContext.Cryptos.AsEnumerable().OrderBy(s => s.Name);
        }

        public Crypto? Get(int id)
        {
            return _cryptoContext.Cryptos.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Crypto entity)
        {
            _cryptoContext.Cryptos.Update(entity);
            _cryptoContext.SaveChanges();
        }
        public void Delete(Crypto entity)
        {
            _cryptoContext.Cryptos.Remove(entity);
            _cryptoContext.SaveChanges();
        }
    }
}
