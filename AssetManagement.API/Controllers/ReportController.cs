using AssetManagement.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("Dashboard")]
        public IActionResult GetDashboardReport()
        {
            return Ok(_reportService.GetDashboardReport());
        }
    }
}