using FlightService.Domain.Enums;

namespace FlightService.Domain.Dtos.TicketPrice
{
    public class CreateTicketPriceDto
    {

        public Guid FlightId { get; set; }
        public decimal Price { get; set; }
        public SeatClass SeatClass {get; set;}
    }
}
