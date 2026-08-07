using AssetManagement.MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var report = await _reportService.GetDashboardReportAsync();

            return View(report);
        }
    }
}