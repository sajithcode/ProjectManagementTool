namespace backendAPI.Dtos
{
    public class TaskReadDto
    {
        public int TaskItemID { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int ProjectID { get; set; }
        public int? AssignedUserID { get; set; }
        public int CreatedUserID { get; set; }
        public string Status { get; set; }
        public string? Priority { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class TaskCreateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int ProjectID { get; set; }
        public int? AssignedUserID { get; set; }
        public int CreatedUserID { get; set; }
        public string Status { get; set; }
        public string? Priority { get; set; }
    }

    public class TaskUpdateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; }
        public string? Priority { get; set; }
        public bool IsDeleted { get; set; }
    }
}
