using UserService.Domain.Dtos.Auth;
using UserService.Domain.Models;

namespace UserService.Services.AuthServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginDto loginDto);
        Task<User> Register(RegisterDto registerModel);
        Task ForgotPassword(string email);
        Task ResetPassword(string email, string token, string newPassword);
    }
}
