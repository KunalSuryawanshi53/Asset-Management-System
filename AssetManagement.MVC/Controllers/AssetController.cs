using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;
        private readonly ICategoryService _categoryService;

        public AssetController(
            IAssetService assetService,
            ICategoryService categoryService)
        {
            _assetService = assetService;
            _categoryService = categoryService;
        }

        // Display Asset List
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var assets = await _assetService.GetAllAssetsAsync();

            return View(assets);
        }

        // Open Add Asset Page
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            return View();
        }

        // Save Asset
        [HttpPost]
        public async Task<IActionResult> Add(AddAssetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
                return View(model);
            }

            bool result = await _assetService.AddAssetAsync(model);

            if (result)
            {
                TempData["Success"] = "Asset Added Successfully";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Failed to Add Asset");

            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            return View(model);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var asset = await _assetService.GetAssetByIdAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            var model = new UpdateAssetViewModel
            {
                AssetId = asset.AssetId,
                AssetCode = asset.AssetCode,
                AssetName = asset.AssetName,
                CategoryId = asset.CategoryId,
                Brand = asset.Brand,
                SerialNumber = asset.SerialNumber,
                PurchasePrice = asset.PurchasePrice,
                Status = asset.Status
            };

            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            return View(model);
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAssetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
                return View(model);
            }

            bool result = await _assetService.UpdateAssetAsync(model);

            if (result)
            {
                TempData["Success"] = "Asset Updated Successfully";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Failed to Update Asset");

            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _assetService.DeleteAssetAsync(id);

            if (result)
            {
                TempData["Success"] = "Asset Deleted Successfully";
            }
            else
            {
                TempData["Error"] = "Failed to Delete Asset";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}