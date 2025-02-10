using AutoMapper;
using UserService.Domain.Dtos;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.UserRepositories;

namespace UserService.Services.UserServices
{
    public class UsersService : IUserService
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;
        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var listUser = _mapper.Map<List<UserDto>>(users);
            return listUser;
        }
        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            var mappedUser = _mapper.Map<UserDto>(user);
            return mappedUser;
        }
        public async Task<UserDto> CreateUser(UserModel user)
        {
            var newUser = await _userRepository.CreateUser(user);
            var mappedUser = _mapper.Map<UserDto>(newUser);
            return mappedUser;
        }
        public async Task<UserDto> UpdateUser(UserModel user)
        {
            var updatedUser = await _userRepository.UpdateUser(user);
            var mappedUser = _mapper.Map<UserDto>(updatedUser);

            return mappedUser;
        }
        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUserById(id);
        }
    }
}
