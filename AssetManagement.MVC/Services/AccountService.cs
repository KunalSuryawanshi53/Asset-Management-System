using System.Net.Http.Json;
using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponseViewModel?> LoginAsync(LoginViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", model);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<LoginResponseViewModel>();
        }
    }
}