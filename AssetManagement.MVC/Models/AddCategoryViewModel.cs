using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class AddCategoryViewModel
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}