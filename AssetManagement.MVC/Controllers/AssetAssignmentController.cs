using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class AssetAssignmentController : Controller
    {
        private readonly IAssetAssignmentService _assetAssignmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IAssetService _assetService;

        public AssetAssignmentController(
            IAssetAssignmentService assetAssignmentService,
            IEmployeeService employeeService,
            IAssetService assetService)
        {
            _assetAssignmentService = assetAssignmentService;
            _employeeService = employeeService;
            _assetService = assetService;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        [HttpGet]
        public IActionResult Test()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            return Content("AssetAssignment Controller Working");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var assignments = await _assetAssignmentService.GetAllAssignmentsAsync();

            return View(assignments);
        }

        [HttpGet]
        public async Task<IActionResult> Assign()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
            ViewBag.Assets = await _assetService.GetAllAssetsAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(AddAssetAssignmentViewModel model)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
                ViewBag.Assets = await _assetService.GetAllAssetsAsync();

                return View(model);
            }

            bool result = await _assetAssignmentService.AssignAssetAsync(model);

            if (result)
            {
                TempData["Success"] = "Asset Assigned Successfully";

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Asset is already assigned.");

            ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
            ViewBag.Assets = await _assetService.GetAllAssetsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Return(int assignmentId)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            ReturnAssetViewModel model = new()
            {
                AssignmentId = assignmentId,
                ReturnedDate = DateTime.Now
            };

            bool result = await _assetAssignmentService.ReturnAssetAsync(model);

            if (result)
            {
                TempData["Success"] = "Asset Returned Successfully";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}