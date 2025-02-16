using System;
using System.Collections.Generic;
using UserService.Domain.Enums;

namespace UserService.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public string? Nationality { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? Birthday { get; set; }
        public Status Status { get; set; } = Status.Active;
        public Roles Roles { get; set; } = Roles.User;

        public List<Guid>? BookingIds { get; set; } = new List<Guid>();
        public List<Guid>? FlightIds { get; set; } = new List<Guid>();
    }
}