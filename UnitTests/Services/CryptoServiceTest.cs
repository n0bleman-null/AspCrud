using BLL.Entities;
using BLL.Repositories;
using BLL.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    [TestFixture]
    public class CryptoServiceTest
    {
        private ICryptoService _cryptoService;
        private Mock<IRepository<Crypto>> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<ICryptoFinder> _mockFinder;

        private Crypto _crypto;
        private List<Crypto> _cryptoList = new List<Crypto>() {
            new Crypto{ Id = 1, Name = "BTC", Price = 50000, IsToken = false },
            new Crypto{ Id = 2, Name = "ETH", Price = 2400, IsToken = false },
            new Crypto{ Id = 3, Name = "NFT", Price = 5, IsToken = true }
            };
        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IRepository<Crypto>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockFinder = new Mock<ICryptoFinder>();
            _mockFinder.Setup(m => m.GetAll()).Returns(() => Task.Run(() => new List<Crypto>(_cryptoList)));

            _cryptoService = new CryptoService(_mockRepository.Object,
                _mockFinder.Object, _mockUnitOfWork.Object);

            _crypto = new Crypto { Name = "BTC", Price = 40000, IsToken = false };
        }

        [Test]
        public async Task Get()
        {
            var actual = await _cryptoService.GetAllAsync();
            _mockFinder.Verify(m => m.GetAll());
            Assert.IsTrue(actual.SequenceEqual(_cryptoList));
        }

        [Test]
        public void AddCrypto()
        {
            _cryptoService.AddAsync(_crypto);
            _mockRepository.Verify(m => m.AddAsync(_crypto));
            _mockUnitOfWork.Verify(m => m.SaveAsync());
        }

        [Test]
        public void UpdateCrypto()
        {
            _cryptoService.UpdateAsync(_crypto);
            _mockRepository.Verify(m => m.Update(_crypto));
            _mockUnitOfWork.Verify(m => m.SaveAsync());
        }

        [Test]
        public void DeleteCrypto()
        {
            _cryptoService.DeleteAsync(_crypto);
            _mockRepository.Verify(m => m.Delete(_crypto));
            _mockUnitOfWork.Verify(m => m.SaveAsync());
        }

    }
}
