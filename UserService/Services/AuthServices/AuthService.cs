using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserService.Domain.Dtos.Auth;
using UserService.Domain.Dtos.User;
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
            var user = new User
            {
                Email = registerModel.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password),
                Username = registerModel.Username,
            };
            var createdUser = await _userRepository.CreateUser(user);
            createdUser.UpdatedAt = DateTime.UtcNow;
            var lastseen = await _userRepository.UpdateUser(createdUser);
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


        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("supersecretkeyunbeliaveablemysteriouskeyinhooaleeertt");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
