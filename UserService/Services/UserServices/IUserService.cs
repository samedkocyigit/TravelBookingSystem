using UserService.Domain.Dtos;
using UserService.Domain.Models;

namespace UserService.Services.UserServices
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(Guid id);
        Task<UserDto> CreateUser(UserModel user);
        Task<UserDto> UpdateUser(UserModel user);
        Task DeleteUser(Guid id);
    }
}
