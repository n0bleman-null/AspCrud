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
        public async Task<IQueryable<Crypto>> GetAsync()
        {
            return await _cryptoFinder.AsQueryableAsync();
        }
        public async Task AddAsync(Crypto crypto)
        {
            await _cryptoRepository.AddAsync(crypto);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(Crypto crypto)
        {
            await _cryptoRepository.UpdateAsync(crypto);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(Crypto crypto)
        {
            await _cryptoRepository.DeleteAsync(crypto);
            await _unitOfWork.SaveAsync();
        }
    }
}
