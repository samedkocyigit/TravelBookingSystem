﻿using FlightService.Domain.Enums;
using System.Text.Json.Serialization;

namespace FlightService.Domain.Models
{
    public class TicketPrice
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public SeatClass SeatClass { get; set; }
        public decimal Price { get; set; }

        public Guid FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}
