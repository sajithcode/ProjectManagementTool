namespace backendAPI.Dtos
{

    public class UserReadDto
    {
        public int UserID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ContactNo { get; set; }
        public string Password { get; set; } = null!;
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
    public class UserCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ContactNo { get; set; }
        public string Password { get; set; } = null!;
        public int RoleID { get; set; }
    }
    public class UserUpdateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ContactNo { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
}
