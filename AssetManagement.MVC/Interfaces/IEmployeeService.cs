using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllEmployeesAsync(string? keyword = null);

        Task<PagedResult<EmployeeViewModel>> GetEmployeesWithPaginationAsync(int pageNumber, int pageSize);

        Task<EmployeeViewModel?> GetEmployeeByIdAsync(int id);

        Task<bool> AddEmployeeAsync(AddEmployeeViewModel model);

        Task<bool> UpdateEmployeeAsync(UpdateEmployeeViewModel model);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}