using UserService.Domain.Dtos.User;
using UserService.Domain.Models;

namespace UserService.Services.UserServices
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(Guid id);
        Task<UserDto> CreateUser(CreateUserDto user);
        Task<UserDto> UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}
