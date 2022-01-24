using BLL.Entities;
using BLL.Repositories;
using DAL;
using DAL.Finders;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Repositories
{
    [TestFixture]
    public class CryptoDbRepositoryTest
    {
        private IRepository<Crypto> _repository;
        private IUnitOfWork _unitOfWork;
        private ICryptoFinder _finder;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<CryptoContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            var ctx = new CryptoContext(options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            _repository = new CryptoDbRedisRepository(ctx);
            _unitOfWork = new UnitOfWork(ctx);

            var mockRedisClient = new Mock<IRedisClient>();
            var mockRedisDatabase = new Mock<IRedisDatabase>();
            mockRedisDatabase.Setup(m => m.ExistsAsync(It.IsAny<string>(), It.IsAny<CommandFlags>()))
                .Returns(() => Task.Run(() => false));
            mockRedisClient.Setup(m => m.GetDefaultDatabase()).Returns(() => mockRedisDatabase.Object);
            _finder = new CryptoRedisFinder(ctx.Cryptos, mockRedisClient.Object);
        }

        [Test]
        public async Task IsEmptyDb()
        {
            Assert.IsTrue((await _finder.GetAll()).Count() == 0);
        }
        [Test]
        public async Task GetNotExistedObjById()
        {
            Assert.IsNull(await _finder.GetById(-12));
        }
        [Test]
        public async Task GetNotExistedObjByName()
        {
            Assert.IsNull(await _finder.GetByName("EffectiveSoftCoin"));
        }
        [Test]
        public async Task AddToDb()
        {            
            var crypto = new Crypto {Name = "NFT", Price = 100, IsToken = true };
            await _repository.AddAsync(crypto);
            await _unitOfWork.SaveAsync();
            Assert.NotNull(await _finder.GetByName(crypto.Name));
        }
        [Test]
        public async Task UpdateFromDb()
        {
            var crypto = new Crypto { Name = "Monero", Price = 40, IsToken = true };
            await _repository.AddAsync(crypto);
            await _unitOfWork.SaveAsync();

            var newcrypto = await _finder.GetByName(crypto.Name);
            newcrypto.Price = 100;
            _repository.Update(newcrypto);
            await _unitOfWork.SaveAsync();

            Assert.AreEqual((await _finder.GetByName(crypto.Name)).Price, newcrypto.Price);
        }
        [Test]
        public async Task UpdateNotExistedObj()
        {
            var crypto = new Crypto { Name = "MyCoin", Price = 132, IsToken = true };
            _repository.Delete(crypto);
            Assert.Throws<AggregateException>(() => _unitOfWork.SaveAsync().Wait());
        }
        [Test]
        public async Task DeleteFromDb()
        {
            var crypto = new Crypto { Name = "NFT", Price = 100, IsToken = true };
            await _repository.AddAsync(crypto);
            await _unitOfWork.SaveAsync();

            var newcrypto = await _finder.GetByName("NFT");
            _repository.Delete(newcrypto);
            await _unitOfWork.SaveAsync();
            Assert.Null(await _finder.GetByName("NFT"));
        }
        [Test]
        public async Task DeleteNotExistedObj()
        {
            var crypto = new Crypto { Name = "Monero", Price = 40, IsToken = true };
            _repository.Delete(crypto);
            Assert.Throws<AggregateException>(() => _unitOfWork.SaveAsync().Wait());
        }
    }
}
