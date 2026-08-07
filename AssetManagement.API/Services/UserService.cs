using AssetManagementSystem.DTOs;
using AssetManagementSystem.Interfaces;
using AssetManagementSystem.Repositories.Interfaces;
using AssetManagementSystem.Services.Jwt;

namespace AssetManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public LoginResponseDto Login(LoginDto dto)
        {
            var user = _userRepository.Login(dto);

            if (user != null)
            {
                user.Token = _jwtService.GenerateToken(user);
            }

            return user;
        }
    }
}