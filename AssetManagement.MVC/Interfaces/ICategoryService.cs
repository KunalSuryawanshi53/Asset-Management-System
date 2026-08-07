using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();

        Task<CategoryViewModel?> GetCategoryByIdAsync(int id);

        Task<bool> AddCategoryAsync(AddCategoryViewModel model);

        Task<bool> UpdateCategoryAsync(UpdateCategoryViewModel model);

        Task<bool> DeleteCategoryAsync(int id);
    }
}