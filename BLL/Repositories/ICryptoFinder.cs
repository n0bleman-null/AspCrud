using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface ICryptoFinder
    {
        Task<List<Crypto>> GetAll();
        Task<Crypto?> GetByName(string name);
        Task<Crypto?> GetById(int id);
        Task OnCryptoChanged(ICryptoRepository sender, CryptoEventArgs e);
    }
}
