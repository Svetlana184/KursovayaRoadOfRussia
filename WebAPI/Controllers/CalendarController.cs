using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IService<Calendar_> _calendarService;
        public CalendarController(IService<Calendar_> calendarService)
        {
            this._calendarService = calendarService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Calendar_>>> GetAllCalendars()
        {
            var evs = await _calendarService.GetAll();
            return Ok(evs);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<Calendar_>>> GetByIdCalendars(int id)
        {
            var ev = await _calendarService.GetById(id);
            if (ev == null) { return NotFound(); }
            return Ok(ev);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<Calendar_>>> CreateCalendar([FromBody] Calendar_ c)
        {
            await _calendarService.Create(c);
            return CreatedAtAction(nameof(GetByIdCalendars), new { id = c.IdCalendar }, c);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<Calendar_>>> UpdateCalendar(int id, [FromBody] Calendar_ ev)
        {
            if (ev.IdCalendar != id)
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
