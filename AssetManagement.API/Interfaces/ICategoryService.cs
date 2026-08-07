using AssetManagement.API.DTOs;

namespace AssetManagement.API.Interfaces
{
    public interface ICategoryService
    {
        int AddCategory(AddCategoryDto dto);

        List<CategoryResponseDto> GetAllCategories();

        CategoryResponseDto? GetCategoryById(int id);

        int UpdateCategory(UpdateCategoryDto dto);

        int DeleteCategory(int id);
    }
}