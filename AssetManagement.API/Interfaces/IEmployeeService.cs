using AssetManagement.API.DTOs;
using AssetManagement.API.Models;

namespace AssetManagement.API.Interfaces
{
    public interface IEmployeeService
    {
        int AddEmployee(AddEmployeeDto dto);

        List<EmployeeResponseDto> GetAllEmployees();

        EmployeeResponseDto? GetEmployeeById(int id);

        int UpdateEmployee(UpdateEmployeeDto dto);

        int DeleteEmployee(int id);

        List<EmployeeResponseDto> SearchEmployees(string keyword);

        PagedResult<EmployeeResponseDto> GetEmployeesWithPagination(int pageNumber, int pageSize);
    }
}