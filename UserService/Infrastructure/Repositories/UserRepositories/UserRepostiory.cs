using Microsoft.EntityFrameworkCore;
using UserService.Domain.Models;
using UserService.Infrastructure.ApplicationDbContext;

namespace UserService.Infrastructure.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
                       
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<UserModel> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<UserModel> CreateUser(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUserById(Guid id)
        {
            var user = await GetUserById(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}