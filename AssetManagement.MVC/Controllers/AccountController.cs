using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResponse = await _accountService.LoginAsync(model);

            if (loginResponse == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View(model);
            }

            HttpContext.Session.SetString("Token", loginResponse.Token);
            HttpContext.Session.SetString("Username", loginResponse.Username);
            HttpContext.Session.SetString("Role", loginResponse.Role);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}