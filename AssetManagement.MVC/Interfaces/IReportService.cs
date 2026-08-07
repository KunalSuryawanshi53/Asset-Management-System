using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface IReportService
    {
        Task<DashboardReportViewModel?> GetDashboardReportAsync();
    }
}