using BLL.Entities;
using BLL.Repositories;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IRepository<Crypto> _cryptoRepository;
        private readonly IFinder<Crypto> _cryptoFinder;
        private readonly IUnitOfWork _unitOfWork;

        public CryptoService(IRepository<Crypto> repository, IFinder<Crypto> finder, IUnitOfWork unitOfWork)
        {
            _cryptoRepository = repository;
            _cryptoFinder = finder;
            _unitOfWork = unitOfWork;
        }

        //public Crypto? Get(int id)
        //{
        //    return _cryptoRepository.Get(id);
        //}
        public Task<IQueryable<Crypto>> GetAsync()
        {
            return Task.Run(() => _cryptoFinder.AsQueryable());
        }
        public async Task AddAsync(Crypto crypto)
        {
            await _cryptoRepository.AddAsync(crypto);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(Crypto crypto)
        {
            _cryptoRepository.Update(crypto);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(Crypto crypto)
        {
            _cryptoRepository.Delete(crypto);
            await _unitOfWork.SaveAsync();
        }
    }
}
