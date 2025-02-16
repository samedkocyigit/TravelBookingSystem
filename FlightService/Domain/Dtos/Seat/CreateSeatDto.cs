using FlightService.Domain.Enums;

namespace FlightService.Domain.Dtos.Seat
{
    public class CreateSeatDto
    {
        public string SeatNumber { get; set; }
        public SeatClass SeatClass { get; set; }
        public Guid FlightId { get; set; }
        public Guid TicketPriceId { get; set; }
    }
}
