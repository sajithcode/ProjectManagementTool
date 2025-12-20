using backendAPI.Data;
using backendAPI.Dtos;
using backendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectReadDto>> GetAllAsync()
        {
            return await _context.Projects
                .Select(p => new ProjectReadDto
                {
                    ProjectID = p.ProjectID,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    IsActive = p.IsActive,
                    CreatedUserID = p.CreatedUserID,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<ProjectReadDto?> GetByIDAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return null;
            return new ProjectReadDto
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                Description = project.Description,
                IsActive = project.IsActive,
                CreatedUserID = project.CreatedUserID,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt
            };
        }

        public async Task<ProjectReadDto> CreateAsync(ProjectCreateDto dto)
        {
            var project = new Project
            {
                ProjectName = dto.ProjectName,
                Description = dto.Description,
                IsActive = true,
                CreatedUserID = dto.CreatedUserID,
                CreatedAt = DateTime.UtcNow
            };
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return new ProjectReadDto
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                Description = project.Description,
                IsActive = project.IsActive,
                CreatedUserID = project.CreatedUserID,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt
            };
        }

        public async Task<ProjectReadDto?> UpdateAsync(int id, ProjectUpdateDto dto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return null;
            project.ProjectName = dto.ProjectName;
            project.Description = dto.Description;
            project.IsActive = dto.IsActive;
            project.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new ProjectReadDto
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                Description = project.Description,
                IsActive = project.IsActive,
                CreatedUserID = project.CreatedUserID,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeStatusAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;
            project.IsActive = !project.IsActive;
            project.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
