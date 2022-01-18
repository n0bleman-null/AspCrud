using AspCrud.Models;
using AspCrud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspCrud.Controllers
{    
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
            return _cryptoService.GetAllGrypto();
        }
        [HttpGet("{index}")]
        public Crypto? GetCrypto(int index)
        {
            return _cryptoService.GetGrypto(index);
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
        public bool DeleteCrypto(int index)
        {
            return _cryptoService.DeleteCrypto(index);
        }
    }
}
