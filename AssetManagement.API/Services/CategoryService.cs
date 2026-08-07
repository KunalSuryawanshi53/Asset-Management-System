using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;

namespace AssetManagement.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int AddCategory(AddCategoryDto dto)
        {
            return _categoryRepository.AddCategory(dto);
        }

        public List<CategoryResponseDto> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public CategoryResponseDto? GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public int UpdateCategory(UpdateCategoryDto dto)
        {
            return _categoryRepository.UpdateCategory(dto);
        }

        public int DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }
    }
}