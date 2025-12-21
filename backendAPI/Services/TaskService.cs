using backendAPI.Data;
using backendAPI.Dtos;
using backendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllAsync()
        {
            return await _context.TaskItems
                .Select(t => new TaskReadDto
                {
                    TaskItemID = t.TaskItemID,
                    Title = t.Title,
                    Description = t.Description,
                    ProjectID = t.ProjectID,
                    AssignedUserID = t.AssignedUserID,
                    CreatedUserID = t.CreatedUserID,
                    Status = t.Status,
                    Priority = t.Priority,
                    IsDeleted = t.IsDeleted,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<TaskReadDto?> GetByIDAsync(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return null;
            return new TaskReadDto
            {
                TaskItemID = task.TaskItemID,
                Title = task.Title,
                Description = task.Description,
                ProjectID = task.ProjectID,
                AssignedUserID = task.AssignedUserID,
                CreatedUserID = task.CreatedUserID,
                Status = task.Status,
                Priority = task.Priority,
                IsDeleted = task.IsDeleted,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }

        public async Task<TaskReadDto> CreateAsync(TaskCreateDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                AssignedUserID = dto.AssignedUserID,
                CreatedUserID = dto.CreatedUserID,
                Status = dto.Status,
                Priority = dto.Priority,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return new TaskReadDto
            {
                TaskItemID = task.TaskItemID,
                Title = task.Title,
                Description = task.Description,
                ProjectID = task.ProjectID,
                AssignedUserID = task.AssignedUserID,
                CreatedUserID = task.CreatedUserID,
                Status = task.Status,
                Priority = task.Priority,
                IsDeleted = task.IsDeleted,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };

        }

        public async Task<TaskReadDto?> UpdateAsync(int id, TaskUpdateDto dto)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return null;
            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.Priority = dto.Priority;
            task.IsDeleted = dto.IsDeleted;
            task.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new TaskReadDto
            {
                TaskItemID = task.TaskItemID,
                Title = task.Title,
                Description = task.Description,
                ProjectID = task.ProjectID,
                AssignedUserID = task.AssignedUserID,
                CreatedUserID = task.CreatedUserID,
                Status = task.Status,
                Priority = task.Priority,
                IsDeleted = task.IsDeleted,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return false;
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeDeleteStatusAsync(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return false;
            task.IsDeleted = !task.IsDeleted;
            task.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
