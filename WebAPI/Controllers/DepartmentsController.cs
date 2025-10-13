using Microsoft.AspNetCore.Mvc;
using WebAPI;
using Microsoft.EntityFrameworkCore.Storage.Json;
using WebAPI.Services;
using Session2;

namespace WebAPI.Controllers
{
    public class DepartmentsController : ControllerBase
    {
        private readonly IService<Department> _departmentService;
        public DepartmentsController(IService<Department> departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var deps = await _departmentService.GetAll();
            return Ok(deps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetByIdDepartments(int id)
        {
            var dep = await _departmentService.GetById(id);
            if (dep == null) { return NotFound(); }
            return Ok(dep);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Department>>> CreateDepartment([FromBody] Department dep)
        {
            await _departmentService.Create(dep);
            return CreatedAtAction(nameof(GetByIdDepartments), new { id = dep.IdDepartment }, dep);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> UpdateDepartment(int id, [FromBody] Department dep)
        {
            if (dep.IdDepartment != id)
            {
                return BadRequest();
            }
            await _departmentService.Update(dep);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentService.Delete(id);
            return NoContent();
        }
    }
}
