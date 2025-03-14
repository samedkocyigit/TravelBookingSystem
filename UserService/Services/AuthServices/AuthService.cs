using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserService.Domain.Dtos.AuthDtos;
using UserService.Domain.Dtos.UserDtos;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.UserRepositories;
using UserService.Services.EmailServices;
using UserService.Services.TokenServices;

namespace UserService.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IEmailService _emailService;
        protected readonly ITokenService _tokenService;
        protected readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository, IEmailService emailService, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Login(LoginDto loginModel)
        {
            var user = await _userRepository.GetUserByEmail(loginModel.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }
            else
            {
                var token = _tokenService.CreateToken(user);
                var userDto = _mapper.Map<UserDto>(user);
                var loginResponse = new LoginResponse
                {
                    Token = token,
                    User = userDto
                };
                return loginResponse;
            }
        }
        public async Task<User> Register(RegisterDto registerModel)
        {
            registerModel.Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);
            var mappedUser = _mapper.Map<User>(registerModel);
            var createdUser = await _userRepository.CreateUser(mappedUser);

            if (createdUser == null)
            {
                throw new Exception("User creation failed.");
            }

            createdUser.UpdatedAt = DateTime.UtcNow;
            var lastseen = await _userRepository.UpdateUser(createdUser);

            if (lastseen == null)
            {
                throw new Exception("User update failed.");
            }

            return lastseen;
        }

        public async Task ForgotPassword(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                var token = GenerateResetToken();
                user.PasswordResetToken = token;
                user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);
                user.UpdatedAt = DateTime.UtcNow;
                await _userRepository.UpdateUser(user);

                var resetLink = $"http://localhost:5169/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(email)}";

                await _emailService.SendEmailAsync(user.Email, "Password Reset Request",
                          $"here is token={token} to reset your password. This link is valid for 1 hour.");
            }
        }
        private string GenerateResetToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var tokenBytes = new byte[32];
                rng.GetBytes(tokenBytes);
                return Convert.ToBase64String(tokenBytes);
            }
        }
        public async Task ResetPassword(string email, string token, string newPassword)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("Invalid email.");
            }

            if (user.PasswordResetToken != token || user.PasswordResetTokenExpiry < DateTime.UtcNow)
            {
                throw new Exception("Invalid or expired token.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiry = null;

            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.UpdateUser(user);
        }
    }
}
