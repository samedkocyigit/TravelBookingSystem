using FlightService.Domain.Models;

namespace FlightService.Services.TicketPriceServices
{
    public interface ITicketPriceService
    {
        Task<List<TicketPrice>> GetAllTicketPrices();
        Task<TicketPrice> GetTicketPriceById(Guid id);
        Task<TicketPrice> CreateTicketPrice(TicketPrice ticketPrice);
        Task<TicketPrice> UpdateTicketPrice(TicketPrice ticketPrice);
        Task DeleteTicketPrice(Guid id);
    }
}
