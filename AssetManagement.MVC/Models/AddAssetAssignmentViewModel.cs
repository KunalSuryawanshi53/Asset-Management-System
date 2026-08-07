using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class AddAssetAssignmentViewModel
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int AssetId { get; set; }

        public string Remarks { get; set; } = string.Empty;
    }
}