using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        // Category List
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var categories = await _categoryService.GetAllCategoriesAsync();

            return View(categories);
        }

        // Open Add Page
        [HttpGet]
        public IActionResult Add()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            return View();
        }

        // Save Category
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool result = await _categoryService.AddCategoryAsync(model);

            if (result)
            {
                TempData["Success"] = "Category Added Successfully";

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Failed to Add Category");

            return View(model);
        }

        // Open Edit Page
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var model = new UpdateCategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            return View(model);
        }

        // Update Category
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryViewModel model)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool result = await _categoryService.UpdateCategoryAsync(model);

            if (result)
            {
                TempData["Success"] = "Category Updated Successfully";

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Failed to Update Category");

            return View(model);
        }

        // Delete Category
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            bool result = await _categoryService.DeleteCategoryAsync(id);

            if (result)
            {
                TempData["Success"] = "Category Deleted Successfully";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}