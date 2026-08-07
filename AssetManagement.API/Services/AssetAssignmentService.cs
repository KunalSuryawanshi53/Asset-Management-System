using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;

namespace AssetManagement.API.Services
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        private readonly IAssetAssignmentRepository _assetAssignmentRepository;

        public AssetAssignmentService(IAssetAssignmentRepository assetAssignmentRepository)
        {
            _assetAssignmentRepository = assetAssignmentRepository;
        }

        public int AssignAsset(AddAssetAssignmentDto dto)
        {
            return _assetAssignmentRepository.AssignAsset(dto);
        }

        public List<AssetAssignmentResponseDto> GetAllAssignments()
        {
            return _assetAssignmentRepository.GetAllAssignments();
        }

        public int ReturnAsset(ReturnAssetDto dto)
        {
            return _assetAssignmentRepository.ReturnAsset(dto);
        }
    }
}