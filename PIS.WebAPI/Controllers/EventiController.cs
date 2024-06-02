using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventiController : ControllerBase
    {
        private readonly IEventiService _service;

        public EventiController(IEventiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventi()
        {
            var eventi = await _service.GetAllEventiAsync();
            return Ok(eventi);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventi(int id)
        {
            var eventi = await _service.GetEventiByIdAsync(id);
            if (eventi == null)
                return NotFound();
            return Ok(eventi);
        }

        [HttpPost]
        public async Task<IActionResult> PostEventi([FromBody] EventiDomain eventi)
        {
            if (eventi == null)
                return BadRequest();

            var createdEventi = await _service.AddEventiAsync(eventi);
            return CreatedAtAction(nameof(GetEventi), new { id = createdEventi.Id }, createdEventi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventi(int id, [FromBody] EventiDomain eventi)
        {
            if (eventi == null || eventi.Id != id)
                return BadRequest();

            var eventiToUpdate = await _service.GetEventiByIdAsync(id);
            if (eventiToUpdate == null)
                return NotFound();

            await _service.UpdateEventiAsync(eventi);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventi(int id)
        {
            var eventiToDelete = await _service.GetEventiByIdAsync(id);
            if (eventiToDelete == null)
                return NotFound();

            await _service.DeleteEventiAsync(id);
            return NoContent();
        }
    }
}
