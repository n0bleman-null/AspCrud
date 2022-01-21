using BLL.Entities;
using BLL.Repositories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CryptoContext _cryptoContext;
        public UnitOfWork(CryptoContext cryptoContext)
        {
            _cryptoContext = cryptoContext;
        }
        public Task<int> SaveAsync()
        {
            return _cryptoContext.SaveChangesAsync();
        }
    }
}
