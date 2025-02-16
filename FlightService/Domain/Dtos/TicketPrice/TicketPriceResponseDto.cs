using FlightService.Domain.Enums;

namespace FlightService.Domain.Dtos.TicketPrice
{
    public class TicketPriceResponseDto
    {
        public Guid Id { get; set; }
        public SeatClass SeatClass { get; set; }
        public decimal Price { get; set; }

        public Guid FlightId { get; set; }
    }
}
