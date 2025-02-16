using FlightService.Domain.Enums;
using System.Text.Json.Serialization;

namespace FlightService.Domain.Models
{
    public class Seat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SeatNumber { get; set; }
        public SeatClass SeatClass { get; set; }
        public IsBooked IsBooked { get; set; } = IsBooked.No;
        
        public Guid FlightId { get; set; }
        public Flight? Flight { get; set; }

        public Guid TicketPriceId { get; set; }
        public TicketPrice? TicketPrice { get; set; }

    }
}
