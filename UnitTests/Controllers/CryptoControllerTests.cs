using AspCrud.Controllers;
using AspCrud.Mappings;
using AspCrud.Requests;
using AutoMapper;
using BLL.Entities;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Controllers
{
    [TestFixture]
    public class CryptoControllerTests
    {
        private CryptoController _cryptoController;
        private Mock<ICryptoService> _mockCryptoService;
        private IMapper _mapper;
        private Crypto _crypto;
        private List<Crypto> _cryptoList = new List<Crypto> {
            new Crypto { Name = "Zicash", Price = 40, IsToken = false },
            new Crypto { Name = "BTC", Price = 40000, IsToken = false },
            new Crypto { Name = "ETH", Price = 8000, IsToken = false }
        };

        [SetUp]
        public void SetUp()
        {
            _mockCryptoService = new Mock<ICryptoService>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(MappingProfile))));

            _cryptoController = new CryptoController(_mockCryptoService.Object, _mapper);

            _crypto = new Crypto { Name = "BTC", Price = 40000, IsToken = false };
        }        

        [Test]
        public void MapperTest()
        {
            var crypto = new Crypto { Id = 12, Name = "BTC", Price = 40000, IsToken = false };
            var cryptovm = new CryptoViewModel { Id = 12, Name = "BTC", Price = 40000, IsToken = false };
            Assert.AreEqual(_mapper.Map<CryptoViewModel>(crypto), cryptovm);
        }
        [Test]
        public async Task GetByIdNotFound()
        {
            _mockCryptoService.Setup(m => m.GetByIdAsync(It.IsAny<int>())).Returns(() => Task.Run(() => null as Crypto));
            Assert.IsInstanceOf<NotFoundResult>((await _cryptoController.GetById(12)).Result);
        }
        [Test]
        public async Task GetByNameNotFound()
        {
            _mockCryptoService.Setup(m => m.GetByNameAsync(It.IsAny<string>())).Returns(() => Task.Run(() => null as Crypto));
            Assert.IsInstanceOf<NotFoundResult>((await _cryptoController.GetByName("EffectiveCoin")).Result);
        }
        [Test]
        public async Task AddTest()
        {
            await _cryptoController.Add(_crypto);
            _mockCryptoService.Verify(m => m.AddAsync(_crypto));
        }
        [Test]
        public async Task UpdateTest()
        {
            await _cryptoController.Update(_crypto);
            _mockCryptoService.Verify(m => m.UpdateAsync(_crypto));
        }
        [Test]
        public async Task DeleteTest()
        {
            await _cryptoController.Delete(_crypto);
            _mockCryptoService.Verify(m => m.DeleteAsync(_crypto));
        }
    }
}
