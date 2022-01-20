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
        private IMapper _mapper;

        public CryptoController(CryptoService service, IMapper mapper)
        {
            _cryptoService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody]Crypto crypto)
        {
            try
            {
                _cryptoService.AddCrypto(crypto);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<CryptoViewModel>> Get()
        {
            return Ok(_cryptoService.GetAllCrypto().Select(crypto => _mapper.Map<Crypto, CryptoViewModel>(crypto)).ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<CryptoViewModel> Get([FromBody] int id)
        {
            var crypto = _cryptoService.GetCrypto(id);
            if (crypto == null)
                return NotFound();
            return Ok(_mapper.Map<Crypto, CryptoViewModel>(crypto));
        }
        [HttpPut]
        public IActionResult Update([FromBody] Crypto crypto)
        {
            try
            {
                _cryptoService.UpdateCrypto(crypto);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Crypto crypto)
        {
            try
            {
                _cryptoService.DeleteCrypto(crypto);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
