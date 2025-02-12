using FlightService.Domain.Enums;

namespace FlightService.Domain.Models
{
    public class Seat
    {
        public Guid Id  { get; set; } = Guid.NewGuid();
        public Guid FlightId { get; set; }
        public Guid TicketPriceId { get; set; }
        public string SeatNumber { get; set; }
        public SeatClass SeatClass { get; set; }
        public IsBooked IsBooked { get; set; }

        public Flight Flight { get; set; }
        public TicketPrice TicketPrice { get; set; }

    }
}
