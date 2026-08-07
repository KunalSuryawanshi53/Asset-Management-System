using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllDepartmentsAsync();
    }
}