using backendAPI.Dtos;

namespace backendAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetAllAsync();
        Task<TaskReadDto?> GetByIDAsync(int id);
        Task<TaskReadDto> CreateAsync(TaskCreateDto dto);
        Task<TaskReadDto?> UpdateAsync(int id, TaskUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangeDeleteStatusAsync(int id);
    }
}
