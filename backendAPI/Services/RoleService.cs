using backendAPI.Data;
using backendAPI.Dtos;
using backendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleReadDto>> GetAllAsync()
        {
            return await _context.Roles
                .Select(r => new RoleReadDto
                {
                    RoleID = r.RoleID,
                    RoleName = r.RoleName,
                    RoleDescription = r.RoleDescription,
                    Status = r.Status
                })
                .ToListAsync();
        }

        public async Task<RoleReadDto?> GetByIDAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;
            return new RoleReadDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription,
                Status = role.Status
            };
        }

        public async Task<RoleReadDto> CreateAsync(RoleCreateDto dto)
        {
            var role = new Role
            {
                RoleName = dto.RoleName,
                RoleDescription = dto.RoleDescription,
                Status = true
            };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return new RoleReadDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription,
                Status = role.Status
            };
        }

        public async Task<RoleReadDto?> UpdateAsync(int id, RoleUpdateDto dto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;
            role.RoleName = dto.Rolename;
            role.RoleDescription = dto.RoleDescription;
            await _context.SaveChangesAsync();
            return new RoleReadDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription,
                Status = role.Status
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeStatesAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;
            role.Status = !role.Status;
            await _context.SaveChangesAsync();
            return true;
        }

        }
    }
