using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;

namespace AssetManagement.API.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public DashboardReportDto GetDashboardReport()
        {
            return _reportRepository.GetDashboardReport();
        }
    }
}