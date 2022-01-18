using AspCrud.Models;
using AspCrud.Repositories;
using System.Collections.Generic;

namespace AspCrud.Services
{
    public class CryptoService
    {
        private readonly CryptoRepository _cryptoRepository = new CryptoRepository();

        public Crypto? GetGrypto(int index)
        {
            return _cryptoRepository.Get(index);
        }
        public IEnumerable<Crypto> GetAllGrypto()
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
        public bool DeleteCrypto(int index)
        {
            return _cryptoRepository.Delete(index);
        }
    }
}
