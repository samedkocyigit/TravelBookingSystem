using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUserById(Guid id);
    }
}