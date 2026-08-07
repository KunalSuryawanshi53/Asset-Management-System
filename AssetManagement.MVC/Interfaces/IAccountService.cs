using AssetManagement.MVC.Models;

namespace AssetManagement.MVC.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponseViewModel?> LoginAsync(LoginViewModel model);
    }
}