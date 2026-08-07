using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class UpdateAssetViewModel
    {
        [Required]
        public int AssetId { get; set; }

        [Required]
        public string AssetCode { get; set; } = string.Empty;

        [Required]
        public string AssetName { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string SerialNumber { get; set; } = string.Empty;

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;
    }
}