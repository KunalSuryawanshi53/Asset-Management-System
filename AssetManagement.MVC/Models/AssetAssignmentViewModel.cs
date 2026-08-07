namespace AssetManagement.MVC.Models
{
    public class AssetAssignmentViewModel
    {
        public int AssignmentId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public string Remarks { get; set; } = string.Empty;
    }
}