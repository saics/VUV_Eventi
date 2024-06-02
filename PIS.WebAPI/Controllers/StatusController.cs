using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Service.Common;
using PIS.Model;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var statuses = await _service.GetAllStatusAsync();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var status = await _service.GetStatusByIdAsync(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> AddStatus(StatusDomain status)
        {
            var newStatus = await _service.AddStatusAsync(status);
            return CreatedAtAction(nameof(GetStatusById), new { id = newStatus.Id }, newStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusDomain status)
        {
            if (id != status.Id) return BadRequest();
            await _service.UpdateStatusAsync(status);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            await _service.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}
