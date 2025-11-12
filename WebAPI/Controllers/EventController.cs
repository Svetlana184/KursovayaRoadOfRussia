using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IService<Event> _evService;
        public EventController(IService<Event> evService)
        {
            this._evService = evService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var evs = await _evService.GetAll();
            return Ok(evs);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByIdEvents(int id)
        {
            var ev = await _evService.GetById(id);
            if (ev == null) { return NotFound(); }
            return Ok(ev);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<Event>>> CreateEvent([FromBody] Event ev)
        {
            await _evService.Create(ev);
            return CreatedAtAction(nameof(GetByIdEvents), new { id = ev.IdEvent }, ev);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> UpdateEvent(int id, [FromBody] Event ev)
        {
            if (ev.IdEvent != id)
            {
                return BadRequest();
            }
            await _evService.Update(ev);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _evService.Delete(id);
            return NoContent();
        }
    }
}
