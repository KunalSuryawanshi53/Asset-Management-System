using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetAssignmentController : ControllerBase
    {
        private readonly IAssetAssignmentService _assetAssignmentService;

        public AssetAssignmentController(IAssetAssignmentService assetAssignmentService)
        {
            _assetAssignmentService = assetAssignmentService;
        }

        [HttpPost]
        public IActionResult AssignAsset(AddAssetAssignmentDto dto)
        {
            int result = _assetAssignmentService.AssignAsset(dto);

            if (result > 0)
                return Ok("Asset Assigned Successfully");

            return BadRequest("Asset is already assigned.");
        }

        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            return Ok(_assetAssignmentService.GetAllAssignments());
        }

        [HttpPut]
        public IActionResult ReturnAsset(ReturnAssetDto dto)
        {
            int result = _assetAssignmentService.ReturnAsset(dto);

            if (result > 0)
                return Ok("Asset Returned Successfully");

            return BadRequest("Failed to Return Asset");
        }
    }
}