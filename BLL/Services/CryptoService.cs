using BLL.Entities;
using BLL.Repositories;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CryptoService
    {
        private IRepository<Crypto> _cryptoRepository;

        public CryptoService(IRepository<Crypto> repository)
        {
            _cryptoRepository = repository;
        }

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
    }
}
