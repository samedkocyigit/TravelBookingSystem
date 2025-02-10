using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user);
        Task DeleteUserById(Guid id);
    }
}