using AssetManagement.API.DTOs;

namespace AssetManagement.API.Interfaces
{
    public interface IReportRepository
    {
        DashboardReportDto GetDashboardReport();
    }
}