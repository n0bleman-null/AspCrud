using BLL.Entities;
using BLL.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Finders
{
    public class CryptoRedisFinder : CryptoFinder
    {
        private readonly IRedisDatabase _redisDatabase;
        public CryptoRedisFinder(DbSet<Crypto> dbset, IRedisClient redisClient) : base(dbset)
        {
            _redisDatabase = redisClient.GetDefaultDatabase();
        }
        public override async Task<Crypto?> GetById(int id)
        {
            if (await _redisDatabase.ExistsAsync(id.ToString()))
                return await _redisDatabase.GetAsync<Crypto>(id.ToString());
            var result = await base.GetById(id);
            if (result == null)
                return null;
            await _redisDatabase.AddAsync(result.Id.ToString(), result);
            return result;
        }
        public override async Task OnCryptoChanged(ICryptoRepository sender, CryptoEventArgs e)
        { 
            await _redisDatabase.RemoveAsync(e.Id.ToString());
        }
    }
}
