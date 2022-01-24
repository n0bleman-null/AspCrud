using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface ICryptoRepository : IRepository<Crypto>
    {
        event CryptoEventHandler? CryptoChanged;
    }

    public class CryptoEventArgs : EventArgs
    {
        public uint Id { get; set; }
    }

    public delegate void CryptoEventHandler(ICryptoRepository sender, CryptoEventArgs e);
}
