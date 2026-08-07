namespace AssetManagement.API.DTOs
{
    public class UpdateDepartmentDto
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}