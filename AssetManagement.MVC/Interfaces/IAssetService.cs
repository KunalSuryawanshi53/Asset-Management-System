using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface IAssetService
    {
        Task<List<AssetViewModel>> GetAllAssetsAsync();

        Task<AssetViewModel?> GetAssetByIdAsync(int id);

        Task<bool> AddAssetAsync(AddAssetViewModel model);

        Task<bool> UpdateAssetAsync(UpdateAssetViewModel model);

        Task<bool> DeleteAssetAsync(int id);
    }
}