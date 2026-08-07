using AssetManagementSystem.DTOs;
using AssetManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var result = _userService.Login(dto);

            if (result == null)
            {
                return Unauthorized("Invalid Username or Password");
            }

            return Ok(result);
        }
    }
}