using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface IAssetAssignmentService
    {
        Task<List<AssetAssignmentViewModel>> GetAllAssignmentsAsync();

        Task<bool> AssignAssetAsync(AddAssetAssignmentViewModel model);

        Task<bool> ReturnAssetAsync(ReturnAssetViewModel model);
    }
}