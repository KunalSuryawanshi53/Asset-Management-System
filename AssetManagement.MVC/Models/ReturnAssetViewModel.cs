using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class ReturnAssetViewModel
    {
        [Required]
        public int AssignmentId { get; set; }

        [Required]
        public DateTime ReturnedDate { get; set; }
    }
}