namespace backendAPI.Dtos
{
    public class RoleReadDto
    {
        public int RoleID {  get; set; }
        public string RoleName {  get; set; }
        public string? RoleDescription {  get; set; } = null!;
        public bool Status {  get; set; }
    }

    public class RoleCreateDto
    {
        public string RoleName { get; set; } = null!;
        public string RoleDescription { get; set; }
    }

    public class  RoleUpdateDto
    {
        public string Rolename { get; set; }
        public string RoleDescription { get; set; }
        public string Status { get; set; }
    }
}
