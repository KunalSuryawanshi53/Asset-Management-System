using AssetManagement.API.DTOs;

namespace AssetManagement.API.Interfaces
{
    public interface IAssetAssignmentService
    {
        int AssignAsset(AddAssetAssignmentDto dto);

        List<AssetAssignmentResponseDto> GetAllAssignments();

        int ReturnAsset(ReturnAssetDto dto);
    }
}