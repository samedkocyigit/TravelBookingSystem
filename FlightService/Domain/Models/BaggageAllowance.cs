﻿    using FlightService.Domain.Enums;
using System.Text.Json.Serialization;

namespace FlightService.Domain.Models
{
    public class BaggageAllowance
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public SeatClass SeatClass { get; set; }
        public int WeightLimitKg { get; set; }
        public decimal ExtraChargePerKg { get; set; }

        public Guid FlightId { get; set; }
        public Flight?  Flight { get; set; }
    }
}
