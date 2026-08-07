using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(
            IEmployeeService employeeService,
            IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        // Employee List
        [HttpGet]
        public async Task<IActionResult> Index(string? keyword)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var employees = await _employeeService.GetAllEmployeesAsync(keyword);

            ViewBag.Keyword = keyword;

            return View(employees);
        }

        // Pagination
        [HttpGet]
        public async Task<IActionResult> Pagination(int pageNumber = 1, int pageSize = 5)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var result = await _employeeService
                .GetEmployeesWithPaginationAsync(pageNumber, pageSize);

            return View(result);
        }

        // Add Employee
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel model)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();

                return View(model);
            }

            bool result = await _employeeService.AddEmployeeAsync(model);

            if (result)
            {
                TempData["Success"] = "Employee Added Successfully";

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Failed to Add Employee");

            ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();

            return View(model);
        }

        // Edit Employee
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new UpdateEmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                DepartmentId = employee.DepartmentId,
                Designation = employee.Designation,
                HireDate = employee.HireDate
            };

            ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeViewModel model)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();

                return View(model);
            }

            bool result = await _employeeService.UpdateEmployeeAsync(model);

            if (result)
            {
                TempData["Success"] = "Employee Updated Successfully";

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Failed to Update Employee");

            ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();

            return View(model);
        }

        // Delete Employee
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            bool result = await _employeeService.DeleteEmployeeAsync(id);

            if (result)
            {
                TempData["Success"] = "Employee Deleted Successfully";

                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Failed to Delete Employee";

            return RedirectToAction(nameof(Index));
        }
    }
}