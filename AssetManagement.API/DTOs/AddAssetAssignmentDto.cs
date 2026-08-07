namespace AssetManagement.API.DTOs
{
    public class AddAssetAssignmentDto
    {
        public int EmployeeId { get; set; }
        public int AssetId { get; set; }
        public string Remarks { get; set; }
    }
}