using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpPost]
        public IActionResult AddAsset(AddAssetDto dto)
        {
            int result = _assetService.AddAsset(dto);

            if (result > 0)
                return Ok("Asset Added Successfully");

            return BadRequest("Failed to Add Asset");
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            return Ok(_assetService.GetAllAssets());
        }

        [HttpGet("{id}")]
        public IActionResult GetAssetById(int id)
        {
            var asset = _assetService.GetAssetById(id);

            if (asset == null)
                return NotFound("Asset Not Found");

            return Ok(asset);
        }

        [HttpPut]
        public IActionResult UpdateAsset(UpdateAssetDto dto)
        {
            int result = _assetService.UpdateAsset(dto);

            if (result > 0)
                return Ok("Asset Updated Successfully");

            return BadRequest("Failed to Update Asset");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            int result = _assetService.DeleteAsset(id);

            if (result > 0)
                return Ok("Asset Deleted Successfully");

            return BadRequest("Failed to Delete Asset");
        }
    }
}