using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using WebAPI.Services;
using WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IService<Department> _departmentService;
        public DepartmentsController(IService<Department> departmentService)
        {
            this._departmentService = departmentService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var deps = await _departmentService.GetAll();
            return Ok(deps);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetByIdDepartments(int id)
        {
            var dep = await _departmentService.GetById(id);
            if (dep == null) { return NotFound(); }
            return Ok(dep);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<Department>>> CreateDepartment([FromBody] Department dep)
        {
            await _departmentService.Create(dep);
            return CreatedAtAction(nameof(GetByIdDepartments), new { id = dep.IdDepartment }, dep);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> UpdateDepartment(int id, [FromBody] Department dep)
        {
            if (dep.IdDepartment != id)
            {
                return BadRequest();
            }
            await _departmentService.Update(dep);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentService.Delete(id);
            return NoContent();
        }
    }
}
