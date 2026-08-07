using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // Add Department
        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto dto)
        {
            int result = _departmentService.AddDepartment(dto);

            if (result > 0)
                return Ok("Department Added Successfully");

            return BadRequest("Failed to Add Department");
        }

        // Get All Departments
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _departmentService.GetAllDepartments();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = _departmentService.GetDepartmentById(id);

            if (department == null)
            {
                return NotFound("Department Not Found");
            }

            return Ok(department);
        }

        [HttpPut]
        public IActionResult UpdateDepartment(UpdateDepartmentDto dto)
        {
            int result = _departmentService.UpdateDepartment(dto);

            if (result > 0)
            {
                return Ok("Department Updated Successfully");
            }

            return NotFound("Department Not Found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            int result = _departmentService.DeleteDepartment(id);

            if (result > 0)
            {
                return Ok("Department Deleted Successfully");
            }

            return NotFound("Department Not Found");
        }
    }
}