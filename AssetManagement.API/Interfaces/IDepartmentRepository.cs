using AssetManagement.API.DTOs;

namespace AssetManagement.API.Interfaces
{
    public interface IDepartmentRepository
    {
        int AddDepartment(AddDepartmentDto dto);

        List<DepartmentResponseDto> GetAllDepartments();

        DepartmentResponseDto? GetDepartmentById(int id);

        int UpdateDepartment(UpdateDepartmentDto dto);

        int DeleteDepartment(int id);
    }
}