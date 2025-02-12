using FlightService.Domain.Enums;

namespace FlightService.Domain.Models
{
    public class BaggageAllowance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FlightId { get; set; }
        public SeatClass SeatClass { get; set; }
        public int WeightLimitKg { get; set; }
        public decimal ExtraChargePerKg { get; set; }
        public Flight Flight { get; set; }
    }
}
