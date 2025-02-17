using AutoMapper;
using Newtonsoft.Json;
using System.Text;
using UserService.Domain.Dtos;
using UserService.Domain.Enums;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.UserRepositories;

namespace UserService.Services.UserServices
{
    public class UsersService : IUserService
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;
        protected readonly HttpClient _httpClient;
        public UsersService(IUserRepository userRepository, IMapper mapper, HttpClient httpClient)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpClient = httpClient;
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
        public async Task<UserDto> CreateUser(CreateUserDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var mappedUser = _mapper.Map<UserModel>(user);
            var newUser = await _userRepository.CreateUser(mappedUser);
            if(newUser.Roles == Roles.Admin || newUser.Roles == Roles.Manager)
            {
                var url = $"http://hotelservice:8080/api/Hotel/new-manager/{newUser.Id}";
                var response = await _httpClient.PutAsync(url, null);
            }
            var mappedUserDto = _mapper.Map<UserDto>(newUser);
            return mappedUserDto;
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
