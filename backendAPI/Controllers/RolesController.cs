using backendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        //GET: api/Roles/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRoleByID(int id)
        {
            var role = await _roleService.GetByIDAsync(id);
            if (role == null)
                return NotFound();
            return Ok(role);
        }

        //POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] Dtos.RoleCreateDto dto)
        {
            var createdRole = await _roleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetRoleByID), new { id = createdRole.RoleID }, createdRole);
        }

        //PUT: api/Roles/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] Dtos.RoleUpdateDto dto)
        {
            var updateRole = await _roleService.UpdateAsync(id, dto);
            if(updateRole == null) return NotFound();
            return Ok(updateRole);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> ChangeRoleStatus(int id, [FromQuery] bool status)
        {
            var result = await _roleService.ChangeStatesAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
