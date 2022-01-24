using BLL.Entities;
using BLL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CryptoFinder : Finder<Crypto>, ICryptoFinder
    {
        public CryptoFinder(DbSet<Crypto> dbset) : base(dbset) { }
        public Task<List<Crypto>> GetAll()
        {
            return AsQueryable().ToListAsync();
        }
        public Task<Crypto?> GetById(int id)
        {
            return AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Crypto?> GetByName(string name)
        {
            return AsQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
