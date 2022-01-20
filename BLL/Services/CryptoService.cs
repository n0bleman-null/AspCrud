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
        public void AddCrypto(Crypto crypto)
        {
            _cryptoRepository.Add(crypto);
        }
        public void UpdateCrypto(Crypto crypto)
        {
            _cryptoRepository.Update(crypto);
        }
        public void DeleteCrypto(Crypto crypto)
        {
            _cryptoRepository.Delete(crypto);
        }
    }
}
