using AutoMapper;
using Moq;
using UserService.Domain.Dtos.AuthDtos;
using UserService.Domain.Dtos.UserDtos;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.UserRepositories;
using UserService.Services.AuthServices;
using UserService.Services.EmailServices;
using UserService.Services.TokenServices;
using Xunit;

namespace UserService.Tests.LoginTests
{
    public class LoginTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<ITokenService> _mockTokenService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AuthService _authService;

        public LoginTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEmailService = new Mock<IEmailService>();
            _mockTokenService = new Mock<ITokenService>();
            _mockMapper = new Mock<IMapper>();
            _authService = new AuthService(
                _mockUserRepository.Object,
                _mockEmailService.Object,
                _mockTokenService.Object,
                _mockMapper.Object
            );
        }

        [Fact]
        public async Task Login_UserNotFound_ThrowsException()
        {
            var loginDto = new LoginDto { Email = "test@example.com", Password = "password" };
            _mockUserRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync((User)null);

            await Assert.ThrowsAsync<Exception>(() => _authService.Login(loginDto));
        }

        [Fact]
        public async Task Login_InvalidPassword_ThrowsException()
        {
            var loginDto = new LoginDto { Email = "test@example.com", Password = "wrongPassword" };
            var user = new User { Email = "test@example.com", Password = BCrypt.Net.BCrypt.HashPassword("correctPassword") };
            _mockUserRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(user);

            await Assert.ThrowsAsync<Exception>(() => _authService.Login(loginDto));
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsLoginResponse()
        {
            var loginDto = new LoginDto { Email = "test@example.com", Password = "correctPassword" };
            var user = new User { Email = "test@example.com", Password = BCrypt.Net.BCrypt.HashPassword("correctPassword") };
            _mockUserRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(user);
            _mockTokenService.Setup(ts => ts.CreateToken(It.IsAny<User>())).Returns("mockToken");
            _mockMapper.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto { email = "test@example.com" });

            var result = await _authService.Login(loginDto);

            Assert.NotNull(result);
            Assert.Equal(result.Token, "mockToken");
            Assert.Equal(result.User.email, user.Email);
        }
    }
}
