using FlightService.Domain.Enums;

namespace FlightService.Domain.Dtos.Seat
{
    public class SeatResponseDto
    {
        public Guid Id { get; set; }
        public string SeatNumber { get; set; }
        public SeatClass SeatClass { get; set; }
        public IsBooked IsBooked { get; set; }

        public Guid FlightId { get; set; }
        public Guid TicketPriceId { get; set; }
    }
}
