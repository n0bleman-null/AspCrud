using AspCrud.Requests;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Entities;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCrud.Controllers
{
    [Route("[controller]/[action]")]
    public class CryptoController : ControllerBase
    {
        private ICryptoService _cryptoService;
        private IMapper _mapper;

        public CryptoController(ICryptoService service, IMapper mapper)
        {
            _cryptoService = service;
            _mapper = mapper;
        }
        
        [HttpGet] // maybe return IEnumerable?
        public async Task<ActionResult<IQueryable<CryptoViewModel>>> Get()
        {
            return Ok(_mapper.ProjectTo<CryptoViewModel>(await _cryptoService.GetAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Crypto crypto)
        {
            try
            {
                await _cryptoService.AddAsync(crypto);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Crypto crypto)
        {
            try
            {
                await _cryptoService.UpdateAsync(crypto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] Crypto crypto)
        {
            try
            {
                await _cryptoService.DeleteAsync(crypto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
