using FlightService.Domain.Enums;

namespace FlightService.Domain.Dtos.BaggageAllowance
{
    public class CreateBaggageAllowanceDto
    {
        public SeatClass SeatClass { get; set; }
        public int WeightLimitKg { get; set; }
        public decimal ExtraChargePerKg { get; set; }
        public Guid FlightId { get; set; }
    }
}
