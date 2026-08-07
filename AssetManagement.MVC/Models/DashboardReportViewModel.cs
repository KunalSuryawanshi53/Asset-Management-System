namespace AssetManagement.MVC.Models
{
    public class DashboardReportViewModel
    {
        public int TotalAssets { get; set; }

        public int AvailableAssets { get; set; }

        public int AssignedAssets { get; set; }

        public int ReturnedAssets { get; set; }
    }
}