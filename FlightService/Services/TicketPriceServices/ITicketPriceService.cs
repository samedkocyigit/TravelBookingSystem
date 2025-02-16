using FlightService.Domain.Dtos.TicketPrice;
using FlightService.Domain.Models;

namespace FlightService.Services.TicketPriceServices
{
    public interface ITicketPriceService
    {
        Task<List<TicketPriceResponseDto>> GetAllTicketPrices();
        Task<TicketPriceResponseDto> GetTicketPriceById(Guid id);
        Task<TicketPriceResponseDto> CreateTicketPrice(CreateTicketPriceDto ticketPriceDto);
        Task<TicketPriceResponseDto> UpdateTicketPrice(CreateTicketPriceDto ticketPriceDto);
        Task DeleteTicketPrice(Guid id);
    }
}
