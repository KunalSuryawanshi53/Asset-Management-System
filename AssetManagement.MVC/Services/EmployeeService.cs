using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AssetManagement.MVC.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(HttpClient httpClient,
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

        public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync(string? keyword = null)
        {
            AddToken();

            string url = "api/Employee";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                url = $"api/Employee/search?keyword={Uri.EscapeDataString(keyword)}";
            }

            return await _httpClient.GetFromJsonAsync<List<EmployeeViewModel>>(url)
                   ?? new List<EmployeeViewModel>();
        }

        public async Task<PagedResult<EmployeeViewModel>> GetEmployeesWithPaginationAsync(int pageNumber, int pageSize)
        {
            AddToken();

            return await _httpClient.GetFromJsonAsync<PagedResult<EmployeeViewModel>>
            (
                $"api/Employee/pagination?pageNumber={pageNumber}&pageSize={pageSize}"
            ) ?? new PagedResult<EmployeeViewModel>();
        }

        public async Task<EmployeeViewModel?> GetEmployeeByIdAsync(int id)
        {
            AddToken();

            return await _httpClient.GetFromJsonAsync<EmployeeViewModel>($"api/Employee/{id}");
        }

        public async Task<bool> AddEmployeeAsync(AddEmployeeViewModel model)
        {
            AddToken();

            var response = await _httpClient.PostAsJsonAsync("api/Employee", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeViewModel model)
        {
            AddToken();

            var response = await _httpClient.PutAsJsonAsync("api/Employee", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            AddToken();

            var response = await _httpClient.DeleteAsync($"api/Employee/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}