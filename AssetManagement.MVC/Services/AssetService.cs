using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AssetManagement.MVC.Services
{
    public class AssetService : IAssetService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssetService(HttpClient httpClient,
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

        public async Task<List<AssetViewModel>> GetAllAssetsAsync()
        {
            AddToken();

            var assets = await _httpClient.GetFromJsonAsync<List<AssetViewModel>>("api/Asset");

            return assets ?? new List<AssetViewModel>();
        }

        public async Task<AssetViewModel?> GetAssetByIdAsync(int id)
        {
            AddToken();

            return await _httpClient.GetFromJsonAsync<AssetViewModel>($"api/Asset/{id}");
        }

        public async Task<bool> AddAssetAsync(AddAssetViewModel model)
        {
            AddToken();

            var response = await _httpClient.PostAsJsonAsync("api/Asset", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAssetAsync(UpdateAssetViewModel model)
        {
            AddToken();

            var response = await _httpClient.PutAsJsonAsync("api/Asset", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAssetAsync(int id)
        {
            AddToken();

            var response = await _httpClient.DeleteAsync($"api/Asset/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}