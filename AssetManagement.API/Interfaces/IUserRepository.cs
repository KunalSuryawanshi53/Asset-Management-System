using AssetManagementSystem.DTOs;

namespace AssetManagementSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        LoginResponseDto Login(LoginDto dto);
    }
}