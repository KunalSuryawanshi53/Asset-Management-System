using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AssetManagement.MVC.Services
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssetAssignmentService(
            HttpClient httpClient,
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

        // Get All Assignments
        public async Task<List<AssetAssignmentViewModel>> GetAllAssignmentsAsync()
        {
            AddToken();

            var assignments =
                await _httpClient.GetFromJsonAsync<List<AssetAssignmentViewModel>>
                ("api/AssetAssignment");

            return assignments ?? new List<AssetAssignmentViewModel>();
        }

        // Assign Asset
        public async Task<bool> AssignAssetAsync(AddAssetAssignmentViewModel model)
        {
            AddToken();

            var response =
                await _httpClient.PostAsJsonAsync("api/AssetAssignment", model);

            return response.IsSuccessStatusCode;
        }

        // Return Asset
        public async Task<bool> ReturnAssetAsync(ReturnAssetViewModel model)
        {
            AddToken();

            var response =
                await _httpClient.PutAsJsonAsync("api/AssetAssignment", model);

            return response.IsSuccessStatusCode;
        }
    }
}