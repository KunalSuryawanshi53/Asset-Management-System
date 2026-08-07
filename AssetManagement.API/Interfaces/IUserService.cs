using AssetManagementSystem.DTOs;

namespace AssetManagementSystem.Interfaces
{
    public interface IUserService
    {
        LoginResponseDto Login(LoginDto dto);
    }
}