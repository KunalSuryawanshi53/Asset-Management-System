namespace AssetManagement.API.DTOs
{
    public class AddAssetDto
    {
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Status { get; set; }
    }
}