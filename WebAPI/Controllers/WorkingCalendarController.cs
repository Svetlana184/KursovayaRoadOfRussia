using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingCalendarController : ControllerBase
    {
        private readonly IService<WorkingCalendar> _calendarService;
        public WorkingCalendarController(IService<WorkingCalendar> calendarService)
        {
            this._calendarService = calendarService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<WorkingCalendar>>> GetAllCalendars()
        {
            var evs = await _calendarService.GetAll();
            return Ok(evs);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<WorkingCalendar>>> GetByIdCalendars(int id)
        {
            var ev = await _calendarService.GetById(id);
            if (ev == null) { return NotFound(); }
            return Ok(ev);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<WorkingCalendar>>> CreateCalendar([FromBody] WorkingCalendar c)
        {
            await _calendarService.Create(c);
            return CreatedAtAction(nameof(GetByIdCalendars), new { id = c.Id }, c);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<WorkingCalendar>>> UpdateCalendar(int id, [FromBody] WorkingCalendar ev)
        {
            if (ev.Id != id)
            {
                return BadRequest();
            }
            await _calendarService.Update(ev);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCalendar(int id)
        {
            await _calendarService.Delete(id);
            return NoContent();
        }
    }
}
