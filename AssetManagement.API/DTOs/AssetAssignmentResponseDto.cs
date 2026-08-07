namespace AssetManagement.API.DTOs
{
    public class AssetAssignmentResponseDto
    {
        public int AssignmentId { get; set; }
        public string EmployeeName { get; set; }
        public string AssetName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string Remarks { get; set; }
    }
}