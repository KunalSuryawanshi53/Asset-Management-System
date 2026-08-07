using AssetManagement.MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IReportService _reportService;

        public DashboardController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var report = await _reportService.GetDashboardReportAsync();

            return View(report);
        }
    }
}