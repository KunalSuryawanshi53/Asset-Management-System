using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AssetManagement.MVC.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentService(
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

        public async Task<List<DepartmentViewModel>> GetAllDepartmentsAsync()
        {
            AddToken();

            var departments = await _httpClient.GetFromJsonAsync<List<DepartmentViewModel>>("api/Department");

            return departments ?? new List<DepartmentViewModel>();
        }
    }
}