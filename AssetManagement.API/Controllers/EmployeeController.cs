using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AssetManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            IEmployeeService employeeService,
            ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto dto)
        {
            _logger.LogInformation("Add Employee API Called");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Employee Data Received");
                return BadRequest(ModelState);
            }

            int result = _employeeService.AddEmployee(dto);

            if (result > 0)
            {
                _logger.LogInformation("Employee Added Successfully");
                return Ok("Employee Added Successfully");
            }

            _logger.LogError("Failed to Add Employee");

            return BadRequest("Failed to Add Employee");
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            _logger.LogInformation("Get All Employees API Called");

            var employees = _employeeService.GetAllEmployees();

            _logger.LogInformation("Total Employees Found : {Count}", employees.Count);

            return Ok(employees);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            _logger.LogInformation("Get Employee By Id API Called. EmployeeId : {EmployeeId}", id);

            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                _logger.LogWarning("Employee Not Found. EmployeeId : {EmployeeId}", id);
                return NotFound("Employee Not Found");
            }

            _logger.LogInformation("Employee Retrieved Successfully. EmployeeId : {EmployeeId}", id);

            return Ok(employee);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployee(UpdateEmployeeDto dto)
        {
            _logger.LogInformation("Update Employee API Called. EmployeeId : {EmployeeId}", dto.EmployeeId);

            int result = _employeeService.UpdateEmployee(dto);

            if (result > 0)
            {
                _logger.LogInformation("Employee Updated Successfully. EmployeeId : {EmployeeId}", dto.EmployeeId);
                return Ok("Employee Updated Successfully");
            }

            _logger.LogError("Failed To Update Employee. EmployeeId : {EmployeeId}", dto.EmployeeId);

            return BadRequest("Failed to Update Employee");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _logger.LogInformation("Delete Employee API Called. EmployeeId : {EmployeeId}", id);

            int result = _employeeService.DeleteEmployee(id);

            if (result > 0)
            {
                _logger.LogInformation("Employee Deleted Successfully. EmployeeId : {EmployeeId}", id);
                return Ok("Employee Deleted Successfully");
            }

            _logger.LogError("Failed To Delete Employee. EmployeeId : {EmployeeId}", id);

            return BadRequest("Failed to Delete Employee");
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("search")]
        public IActionResult SearchEmployees(string keyword)
        {
            _logger.LogInformation(
                "Search Employee API Called. Keyword : {Keyword}",
                keyword);

            var employees = _employeeService.SearchEmployees(keyword);

            _logger.LogInformation(
                "Search Completed. Records Found : {Count}",
                employees.Count);

            return Ok(employees);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("pagination")]
        public IActionResult GetEmployeesWithPagination(int pageNumber = 1, int pageSize = 5)
        {
            _logger.LogInformation(
                "Pagination API Called. PageNumber : {PageNumber}, PageSize : {PageSize}",
                pageNumber,
                pageSize);

            var employees = _employeeService.GetEmployeesWithPagination(pageNumber, pageSize);

            if (employees == null || employees.Data.Count == 0)
            {
                _logger.LogWarning(
                    "No Employees Found For PageNumber : {PageNumber}",
                    pageNumber);

                return NotFound("No Employees Found");
            }

            _logger.LogInformation(
                "Pagination Successful. Records Returned : {Count}",
                employees.Data.Count);

            return Ok(employees);
        }
    }
}