using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;

namespace AssetManagement.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(AddDepartmentDto dto)
        {
            return _departmentRepository.AddDepartment(dto);
        }

        public List<DepartmentResponseDto> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public DepartmentResponseDto? GetDepartmentById(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }

        public int UpdateDepartment(UpdateDepartmentDto dto)
        {
            return _departmentRepository.UpdateDepartment(dto);
        }

        public int DeleteDepartment(int id)
        {
            return _departmentRepository.DeleteDepartment(id);
        }
    }
}