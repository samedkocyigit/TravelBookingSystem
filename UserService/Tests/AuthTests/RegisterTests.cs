using AutoMapper;
using Moq;
using UserService.Domain.Dtos.AuthDtos;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.UserRepositories;
using UserService.Services.AuthServices;
using UserService.Services.EmailServices;
using UserService.Services.TokenServices;
using Xunit;

namespace UserService.Tests.AuthTests
{
    public class RegisterTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AuthService _authService;

        public RegisterTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEmailService = new Mock<IEmailService>();
            _mockMapper = new Mock<IMapper>();
            _authService = new AuthService(
                _mockUserRepository.Object,
                _mockEmailService.Object,
                null,
                _mockMapper.Object
                );
        }

        [Fact]
        public async Task Register_ValidData_ReturnsCreatedUser()
        {
            var registerDto = new RegisterDto
            {
                Email = "test@example.com",
                Password = "Password123",
                Username = "TestUser"
            };
            var mappedUser = new User
            {
                Email = registerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Username = registerDto.Username
            };
            var createdUser = new User
            {
                Email = registerDto.Email,
                Password = mappedUser.Password,
                Username = registerDto.Username,
                UpdatedAt = DateTime.UtcNow
            };

            _mockMapper.Setup(m => m.Map<User>(registerDto)).Returns(mappedUser);
            _mockUserRepository.Setup(repo => repo.CreateUser(mappedUser)).ReturnsAsync(createdUser);
            _mockUserRepository.Setup(repo => repo.UpdateUser(createdUser)).ReturnsAsync(createdUser);

            var result = await _authService.Register(registerDto);

            Assert.NotNull(result);
            Assert.Equal(result.Email,createdUser.Email);
            Assert.Equal(result.Username,createdUser.Username);
        }
    }
}
