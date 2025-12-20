using backendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectsByID(int id)
        {
            var project = await _projectService.GetByIDAsync(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Dtos.ProjectCreateDto dto)
        {
            var createdProject = await _projectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetProjectsByID), new { id = createdProject.ProjectID }, createdProject);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Dtos.ProjectUpdateDto dto)
        {
            var updateProject = await _projectService.UpdateAsync(id, dto);
            if (updateProject == null) return NotFound();
            return Ok(updateProject);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> ChangeProjectStatus(int id, [FromQuery] bool status)
        {
            var result = await _projectService.ChangeStatusAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
