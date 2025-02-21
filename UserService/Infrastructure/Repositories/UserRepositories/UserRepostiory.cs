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

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u=> u.Payments).ToListAsync();
        }
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.Include(u=> u.Payments).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(User user)
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