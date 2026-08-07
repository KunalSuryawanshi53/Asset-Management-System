using AssetManagement.API.DTOs;

namespace AssetManagement.API.Interfaces
{
    public interface IReportService
    {
        DashboardReportDto GetDashboardReport();
    }
}