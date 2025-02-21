using UserService.Domain.Enums;

namespace UserService.Domain.Dtos.User
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public string? Nationality { get; set; }
        public Roles? Roles { get; set; }
    }
}
