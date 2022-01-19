using AspCrud.Models;
using AspCrud.Repositories;
using System.Collections.Generic;

namespace AspCrud.Services
{
    public class CryptoService
    {
        private readonly CryptoRepository _cryptoRepository = new CryptoRepository();

        public Crypto? GetCrypto(int id)
        {
            return _cryptoRepository.Get(id);
        }
        public IEnumerable<Crypto> GetAllCrypto()
        {
            return _cryptoRepository.Get();
        }
        public bool AddCrypto(Crypto crypto)
        {
            return _cryptoRepository.Add(crypto);
        }
        public bool UpdateCrypto(Crypto crypto)
        {
            return _cryptoRepository.Update(crypto);
        }
        public bool DeleteCrypto(Crypto crypto)
        {
            return _cryptoRepository.Delete(crypto);
        }
        public bool DeleteCrypto(int id)
        {
            return _cryptoRepository.Delete(id);
        }
    }
}
