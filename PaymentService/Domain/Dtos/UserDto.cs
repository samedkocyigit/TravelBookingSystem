﻿namespace PaymentService.Domain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname  { get; set; }
        public List<PaymentDto> Payments { get; set; }
    }
}
