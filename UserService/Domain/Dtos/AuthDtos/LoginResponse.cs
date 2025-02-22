using UserService.Domain.Dtos.UserDtos;

namespace UserService.Domain.Dtos.AuthDtos
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
