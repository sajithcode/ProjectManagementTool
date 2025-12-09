using backendAPI.Dtos;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace backendAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto?> GetByIDAsync(int id);
        Task<UserReadDto> CreateAsync(UserCreateDto dto);
        Task<UserReadDto?> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangeActiveStatusAsync(int id, bool isActive);
    }
}