﻿namespace UserService.Domain.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
