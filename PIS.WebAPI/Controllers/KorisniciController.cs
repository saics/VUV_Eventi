using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;

        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKorisnici()
        {
            var korisnici = await _service.GetAllKorisniciAsync();
            return Ok(korisnici);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKorisnici(int id)
        {
            var korisnici = await _service.GetKorisniciByIdAsync(id);
            if (korisnici == null)
                return NotFound();
            return Ok(korisnici);
        }

        [HttpPost]
        public async Task<IActionResult> PostKorisnici([FromBody] KorisniciDomain korisnici)
        {
            if (korisnici == null)
                return BadRequest();

            var createdKorisnici = await _service.AddKorisniciAsync(korisnici);
            return CreatedAtAction(nameof(GetKorisnici), new { id = createdKorisnici.Id }, createdKorisnici);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisnici(int id, [FromBody] KorisniciDomain korisnici)
        {
            if (korisnici == null || korisnici.Id != id)
                return BadRequest();

            var korisniciToUpdate = await _service.GetKorisniciByIdAsync(id);
            if (korisniciToUpdate == null)
                return NotFound();

            await _service.UpdateKorisniciAsync(korisnici);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnici(int id)
        {
            var korisniciToDelete = await _service.GetKorisniciByIdAsync(id);
            if (korisniciToDelete == null)
                return NotFound();

            await _service.DeleteKorisniciAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Lozinka))
                return BadRequest("Invalid login request");

            var korisnik = await _service.AuthenticateAsync(loginRequest.Email, loginRequest.Lozinka);
            if (korisnik == null)
                return Unauthorized();

            return Ok(korisnik);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Lozinka { get; set; }
    }
}
