namespace backendAPI.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
