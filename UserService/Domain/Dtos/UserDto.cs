﻿namespace UserService.Domain.Dtos
{
    public class UserDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public int age { get; set; }
        public string nationality { get; set; }
        public DateTime birthday { get; set; }

    }
}
