using AssetManagement.API.DTOs;

namespace AssetManagement.API.Interfaces
{
    public interface IAssetRepository
    {
        int AddAsset(AddAssetDto dto);

        List<AssetResponseDto> GetAllAssets();

        AssetResponseDto? GetAssetById(int id);

        int UpdateAsset(UpdateAssetDto dto);

        int DeleteAsset(int id);
    }
}