using BLL.Entities;
using BLL.Repositories;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly ICryptoFinder _cryptoFinder;
        private readonly IUnitOfWork _unitOfWork;

        public CryptoService(ICryptoRepository repository, ICryptoFinder finder, IUnitOfWork unitOfWork)
        {
            _cryptoRepository = repository;
            _cryptoFinder = finder;
            _unitOfWork = unitOfWork;
        }
        public async Task<Crypto?> GetByIdAsync(int id)
        {
            return await _cryptoFinder.GetById(id);
        }

        public Task<Crypto?> GetByNameAsync(string name)
        {
            return _cryptoFinder.GetByName(name);
        }

        public async Task<List<Crypto>> GetAllAsync()
        {
            return await _cryptoFinder.GetAll();
        }
        public async Task AddAsync(Crypto crypto)
        {
            await _cryptoRepository.AddAsync(crypto);
            await _unitOfWork.SaveAsync();
        }
        public Task UpdateAsync(Crypto crypto)
        {
            _cryptoRepository.Update(crypto);
            return _unitOfWork.SaveAsync();
        }
        public Task DeleteAsync(Crypto crypto)
        {
            _cryptoRepository.Delete(crypto);
            return _unitOfWork.SaveAsync();
        }
    }
}
