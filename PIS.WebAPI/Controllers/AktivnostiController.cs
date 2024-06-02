using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Service.Common;
using PIS.Model;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AktivnostiController : ControllerBase
    {
        private readonly IAKtivnostiService _service;

        public AktivnostiController(IAKtivnostiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAktivnosti()
        {
            var aktivnosti = await _service.GetAllAktivnostiAsync();
            return Ok(aktivnosti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAktivnostiById(int id)
        {
            var aktivnosti = await _service.GetAktivnostiByIdAsync(id);
            if (aktivnosti == null) return NotFound();
            return Ok(aktivnosti);
        }

        [HttpPost]
        public async Task<IActionResult> AddAktivnosti(AktivnostiDomain aktivnosti)
        {
            var newAktivnosti = await _service.AddAktivnostiAsync(aktivnosti);
            return CreatedAtAction(nameof(GetAktivnostiById), new { id = newAktivnosti.Id }, newAktivnosti);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAktivnosti(int id, AktivnostiDomain aktivnosti)
        {
            if (id != aktivnosti.Id) return BadRequest();
            await _service.UpdateAktivnostiAsync(aktivnosti);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAktivnosti(int id)
        {
            await _service.DeleteAktivnostiAsync(id);
            return NoContent();
        }
    }
}
