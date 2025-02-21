using UserService.Domain.Models;

namespace UserService.Services.TokenServices
{
    public interface ITokenService
    {
        string CreateToken(User user);

    }
}
