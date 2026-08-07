using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;

namespace AssetManagement.API.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public int AddAsset(AddAssetDto dto)
        {
            return _assetRepository.AddAsset(dto);
        }

        public List<AssetResponseDto> GetAllAssets()
        {
            return _assetRepository.GetAllAssets();
        }

        public AssetResponseDto? GetAssetById(int id)
        {
            return _assetRepository.GetAssetById(id);
        }

        public int UpdateAsset(UpdateAssetDto dto)
        {
            return _assetRepository.UpdateAsset(dto);
        }

        public int DeleteAsset(int id)
        {
            return _assetRepository.DeleteAsset(id);
        }
    }
}