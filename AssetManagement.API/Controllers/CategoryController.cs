using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto dto)
        {
            int result = _categoryService.AddCategory(dto);

            if (result > 0)
                return Ok("Category Added Successfully");

            return BadRequest("Failed to Add Category");
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound("Category Not Found");

            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            int result = _categoryService.UpdateCategory(dto);

            if (result > 0)
                return Ok("Category Updated Successfully");

            return BadRequest("Failed to Update Category");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            int result = _categoryService.DeleteCategory(id);

            if (result > 0)
                return Ok("Category Deleted Successfully");

            return BadRequest("Failed to Delete Category");
        }
    }
}