using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AssetManagement.MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(HttpClient httpClient,
                               IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        private void AddToken()
        {
            var token = _httpContextAccessor.HttpContext?
                .Session.GetString("Token");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // Get All Categories
        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            AddToken();

            var categories = await _httpClient.GetFromJsonAsync<List<CategoryViewModel>>("api/Category");

            return categories ?? new List<CategoryViewModel>();
        }

        // Get Category By Id
        public async Task<CategoryViewModel?> GetCategoryByIdAsync(int id)
        {
            AddToken();

            return await _httpClient.GetFromJsonAsync<CategoryViewModel>($"api/Category/{id}");
        }

        // Add Category
        public async Task<bool> AddCategoryAsync(AddCategoryViewModel model)
        {
            AddToken();

            var response = await _httpClient.PostAsJsonAsync("api/Category", model);

            return response.IsSuccessStatusCode;
        }

        // Update Category
        public async Task<bool> UpdateCategoryAsync(UpdateCategoryViewModel model)
        {
            AddToken();

            var response = await _httpClient.PutAsJsonAsync("api/Category", model);

            return response.IsSuccessStatusCode;
        }

        // Delete Category
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            AddToken();

            var response = await _httpClient.DeleteAsync($"api/Category/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}