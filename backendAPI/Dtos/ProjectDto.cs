namespace backendAPI.Dtos
{
    public class ProjectReadDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ProjectCreateDto
    {
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        public int CreatedUserID { get; set; }
    }

    public class ProjectUpdateDto
    {
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
