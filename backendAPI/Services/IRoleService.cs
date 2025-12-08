using backendAPI.Dtos;

namespace backendAPI.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleReadDto>> GetAllAsync();
        Task<RoleReadDto?> GetByIDAsync(int id);
        Task<RoleReadDto> CreateAsync(RoleCreateDto dto);
        Task<RoleReadDto?> UpdateAsync(int id, RoleUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangeStatesAsync(int id);


    }
}
