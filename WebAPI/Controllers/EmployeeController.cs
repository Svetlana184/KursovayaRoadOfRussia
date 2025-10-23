using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> _empService;
        public EmployeeController(IService<Employee> empService)
        {
            this._empService = empService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var deps = await _empService.GetAll();
            return Ok(deps);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetByIdEmployees(int id)
        {
            var dep = await _empService.GetById(id);
            if (dep == null) { return NotFound(); }
            return Ok(dep);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<Employee>>> CreateEmployee([FromBody] Employee emp)
        {
            await _empService.Create(emp);
            return CreatedAtAction(nameof(GetByIdEmployees), new { id = emp.IdEmployee}, emp);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployee(int id, [FromBody] Employee emp)
        {
            if (emp.IdEmployee != id)
            {
                return BadRequest();
            }
            await _empService.Update(emp);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _empService.Delete(id);
            return NoContent();
        }
    }
}
