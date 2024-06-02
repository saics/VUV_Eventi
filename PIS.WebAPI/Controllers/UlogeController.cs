using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Service.Common;
using PIS.Model;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UlogeController : ControllerBase
    {
        private readonly IUlogeService _service;

        public UlogeController(IUlogeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUloge()
        {
            var uloge = await _service.GetAllUlogeAsync();
            return Ok(uloge);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUlogeById(int id)
        {
            var uloge = await _service.GetUlogeByIdAsync(id);
            if (uloge == null) return NotFound();
            return Ok(uloge);
        }

        [HttpPost]
        public async Task<IActionResult> AddUloge(UlogeDomain uloge)
        {
            var newUloge = await _service.AddUlogeAsync(uloge);
            return CreatedAtAction(nameof(GetUlogeById), new { id = newUloge.Id }, newUloge);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUloge(int id, UlogeDomain uloge)
        {
            if (id != uloge.Id) return BadRequest();
            await _service.UpdateUlogeAsync(uloge);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUloge(int id)
        {
            await _service.DeleteUlogeAsync(id);
            return NoContent();
        }
    }
}
