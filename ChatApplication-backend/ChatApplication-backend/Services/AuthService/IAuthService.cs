using ChatApplication_backend.Dtos;
using ChatApplication_backend.Models;

namespace ChatApplication_backend.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetUserDto>> Register(AddUserDto user);
        Task<ServiceResponse<GetUserDto>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
