using BLL.Entities;
using BLL.Repositories;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CryptoDbRedisRepository : CryptoDbRepository
    {
        public override event CryptoEventHandler? CryptoChanged; // kostyl
        public CryptoDbRedisRepository(CryptoContext cryptoContext) : base(cryptoContext)
        { }
        public override void Update(Crypto entity)
        {
            CryptoChanged?.Invoke(this, new CryptoEventArgs { Id = entity.Id });
            base.Update(entity);
        }
        public override void Delete(Crypto entity)
        {
            CryptoChanged?.Invoke(this, new CryptoEventArgs { Id = entity.Id });
            base.Delete(entity);
        }

    }
}
