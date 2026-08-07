using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class UpdateCategoryViewModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}