using BLL.Entities;
using BLL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Finders
{
    public abstract class CryptoFinder : Finder<Crypto>, ICryptoFinder
    {
        public CryptoFinder(DbSet<Crypto> dbset) : base(dbset) { }
        public virtual Task<List<Crypto>> GetAll()
        {
            return AsQueryable().ToListAsync();
        }
        public virtual Task<Crypto?> GetById(int id)
        {
            return AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual Task<Crypto?> GetByName(string name)
        {
            return AsQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
        public abstract Task OnCryptoChanged(ICryptoRepository sender, CryptoEventArgs e);        
    }
}
