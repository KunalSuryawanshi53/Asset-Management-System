namespace AssetManagement.API.DTOs
{
    public class AssetResponseDto
    {
        public int AssetId { get; set; }

        public string AssetCode { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public int CategoryId { get; set; }   

        public string CategoryName { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

        public decimal PurchasePrice { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}