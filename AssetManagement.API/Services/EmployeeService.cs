using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using AssetManagement.API.Models;

namespace AssetManagement.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public int AddEmployee(AddEmployeeDto dto)
        {
            return _employeeRepository.AddEmployee(dto);
        }

        public List<EmployeeResponseDto> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public EmployeeResponseDto? GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            return _employeeRepository.UpdateEmployee(dto);
        }

        public int DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public List<EmployeeResponseDto> SearchEmployees(string keyword)
        {
            return _employeeRepository.SearchEmployees(keyword);
        }

        public PagedResult<EmployeeResponseDto> GetEmployeesWithPagination(int pageNumber, int pageSize)
        {
            return _employeeRepository.GetEmployeesWithPagination(pageNumber, pageSize);
        }
    }
}