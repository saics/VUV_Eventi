using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Service.Common;
using PIS.Model;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciAktivnostiController : ControllerBase
    {
        private readonly IKorisniciAktivnostiService _service;

        public KorisniciAktivnostiController(IKorisniciAktivnostiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKorisniciAktivnosti()
        {
            var korisniciAktivnosti = await _service.GetAllKorisniciAktivnostiAsync();
            return Ok(korisniciAktivnosti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKorisniciAktivnostiById(int id)
        {
            var korisniciAktivnosti = await _service.GetKorisniciAktivnostiByIdAsync(id);
            if (korisniciAktivnosti == null) return NotFound();
            return Ok(korisniciAktivnosti);
        }

        [HttpPost]
        public async Task<IActionResult> AddKorisniciAktivnosti(KorisniciAktivnostiDomain korisniciAktivnosti)
        {
            var newKorisniciAktivnosti = await _service.AddKorisniciAktivnostiAsync(korisniciAktivnosti);
            return CreatedAtAction(nameof(GetKorisniciAktivnostiById), new { id = newKorisniciAktivnosti.Id }, newKorisniciAktivnosti);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisniciAktivnosti(int id, KorisniciAktivnostiDomain korisniciAktivnosti)
        {
            if (id != korisniciAktivnosti.Id) return BadRequest();
            await _service.UpdateKorisniciAktivnostiAsync(korisniciAktivnosti);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisniciAktivnosti(int id)
        {
            await _service.DeleteKorisniciAktivnostiAsync(id);
            return NoContent();
        }
    }
}
