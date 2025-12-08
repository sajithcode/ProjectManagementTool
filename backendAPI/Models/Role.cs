namespace backendAPI.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public string? RoleDescription { get; set; }
        public bool Status { get; set; } = true;
    }
}