using UserService.Domain.Dtos.User;

namespace UserService.Domain.Dtos.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
