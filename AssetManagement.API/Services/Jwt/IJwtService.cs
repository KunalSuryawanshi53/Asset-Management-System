using AssetManagementSystem.DTOs;

namespace AssetManagementSystem.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(LoginResponseDto user);
    }
}