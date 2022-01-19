using AspCrud.Models;
using AspCrud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspCrud.Controllers
{
    [Route("[controller]/[action]")]
    public class CryptoController : ControllerBase
    {
        private readonly CryptoService _cryptoService = new CryptoService();

        [HttpPost]
        public bool AddCrypto(Crypto crypto)
        {
            return _cryptoService.AddCrypto(crypto);
        }
        [HttpGet]
        public IEnumerable<Crypto> GetCrypto()
        {
            return _cryptoService.GetAllCrypto().ToList();
        }
        [HttpGet("{id}")]
        public Crypto? GetCrypto(int id)
        {
            return _cryptoService.GetCrypto(id);
        }
        [HttpPut]
        public bool UpdateCrypto(Crypto crypto)
        {
            return _cryptoService.UpdateCrypto(crypto);
        }
        [HttpDelete]
        public bool DeleteCrypto(Crypto crypto)
        {
            return _cryptoService.DeleteCrypto(crypto);
        }
        [HttpDelete]
        public bool DeleteCrypto(int id)
        {
            return _cryptoService.DeleteCrypto(id);
        }
    }
}
