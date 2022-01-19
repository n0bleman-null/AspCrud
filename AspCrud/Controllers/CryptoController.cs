using AspCrud.Requests;
using AutoMapper;
using BLL.Entities;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspCrud.Controllers
{
    [Route("[controller]/[action]")]
    public class CryptoController : ControllerBase
    {
        private CryptoService _cryptoService;
        private Mapper _mapper;

        public CryptoController(CryptoService service)
        {
            _cryptoService = service;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Crypto, CryptoViewModel>());
            _mapper = new Mapper(config);
        }

        [HttpPost]
        public bool AddCrypto([FromBody]Crypto crypto)
        {
            return _cryptoService.AddCrypto(crypto);
        }
        [HttpGet]
        public IEnumerable<CryptoViewModel> GetCrypto()
        {
            return _cryptoService.GetAllCrypto().Select(crypto => _mapper.Map<Crypto, CryptoViewModel>(crypto)).ToList();
        }
        [HttpGet("{id}")]
        public CryptoViewModel? GetCrypto([FromBody] int id)
        {
            var crypto = _cryptoService.GetCrypto(id);
            if (crypto == null)
                return null;
            return _mapper.Map<Crypto, CryptoViewModel>(crypto);
        }
        [HttpPut]
        public bool UpdateCrypto([FromBody] Crypto crypto)
        {
            return _cryptoService.UpdateCrypto(crypto);
        }
        [HttpDelete]
        public bool DeleteCrypto([FromBody] Crypto crypto)
        {
            return _cryptoService.DeleteCrypto(crypto);
        }
    }
}
