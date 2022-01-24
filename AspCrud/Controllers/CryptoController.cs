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
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptoViewModel>>> Get()
        {
            return Ok((await _cryptoService.GetAllAsync()).Select(c => _mapper.Map<CryptoViewModel>(c)));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CryptoViewModel>> GetById(int id)
        {
            var item = await _cryptoService.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<CryptoViewModel>> GetByName(string name)
        {
            var item = await _cryptoService.GetByNameAsync(name);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Crypto crypto)
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
        public async Task<IActionResult> Update([FromBody] Crypto crypto)
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
        public async Task<IActionResult> Delete([FromBody] Crypto crypto)
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
