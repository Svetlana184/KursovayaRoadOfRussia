using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        public UserController(IService<User> userService)
        {
            this._userService = userService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var deps = await _userService.GetAll();
            return Ok(deps);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetByIdUsers(int id)
        {
            var dep = await _userService.GetById(id);
            if (dep == null) { return NotFound(); }
            return Ok(dep);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser([FromBody] User dep)
        {
            await _userService.Create(dep);
            return CreatedAtAction(nameof(GetByIdUsers), new { id = dep.IdUser }, dep);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> UpdateUser(int id, [FromBody] User dep)
        {
            if (dep.IdUser != id)
            {
                return BadRequest();
            }
            await _userService.Update(dep);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }

}
