using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.TicketPriceRepositories
{
    public interface ITicketPriceRepository
    {
        Task<List<TicketPrice>> GetAllTicketPrices();
        Task<TicketPrice> GetTicketPriceById(Guid id);
        Task<TicketPrice> CreateTicketPrice(TicketPrice ticketPrice);
        Task<TicketPrice> UpdateTicketPrice(TicketPrice ticketPrice);
        Task DeleteTicketPrice(Guid id);
    }
}
