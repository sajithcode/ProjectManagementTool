using backendAPI.Data;
using backendAPI.Dtos;
using backendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserReadDto
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ContactNo = u.ContactNo,
                    RoleID = u.RoleID,
                    IsActive = u.IsActive
                })
                .ToListAsync();
        }

        public async Task<UserReadDto> GetByIDAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;
            return new UserReadDto
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ContactNo = user.ContactNo,
                RoleID = user.RoleID,
                IsActive = user.IsActive
            };
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                ContactNo = dto.ContactNo,
                Password = dto.Password,
                RoleID = dto.RoleID,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserReadDto
            {
                UserID = user.UserID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                ContactNo = dto.ContactNo,
                RoleID = dto.RoleID,
                IsActive = user.IsActive
            };
        }

        public async Task<UserReadDto?> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.ContactNo = dto.ContactNo;
            user.RoleID = dto.RoleID;
            user.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return new UserReadDto
            {
                UserID = user.UserID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ContactNo = dto.ContactNo,
                RoleID = dto.RoleID,
                IsActive = user.IsActive
            };
        } 

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeActiveStatusAsync(int id,  bool isActive)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.IsActive = isActive;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
