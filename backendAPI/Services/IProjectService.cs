using backendAPI.Dtos;

namespace backendAPI.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectReadDto>> GetAllAsync();
        Task<ProjectReadDto?> GetByIDAsync(int id);
        Task<ProjectReadDto> CreateAsync(ProjectCreateDto dto);
        Task<ProjectReadDto?> UpdateAsync(int id, ProjectUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangeStatusAsync(int id);
    }
}
