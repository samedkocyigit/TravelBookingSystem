using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.TicketPriceRepositories;

namespace FlightService.Services.TicketPriceServices
{
    public class TicketPriceService: ITicketPriceService
    {
        protected readonly ITicketPriceRepository _ticketPriceRepository;
        public TicketPriceService(ITicketPriceRepository ticketPriceRepository)
        {
            _ticketPriceRepository = ticketPriceRepository;
        }

        public async Task<List<TicketPrice>> GetAllTicketPrices()
        {
            var ticketPrices = await _ticketPriceRepository.GetAllTicketPrices();
            return ticketPrices;
        }
        public async Task<TicketPrice> GetTicketPriceById(Guid id)
        {
            var ticketPrice = await _ticketPriceRepository.GetTicketPriceById(id);
            return ticketPrice;
        }
        public async Task<TicketPrice> CreateTicketPrice(TicketPrice ticketPrice)
        {
            var newTicketPrice = await _ticketPriceRepository.CreateTicketPrice(ticketPrice);
            return newTicketPrice;
        }

        public async Task<TicketPrice> UpdateTicketPrice(TicketPrice ticketPrice)
        {
            var updatedTicketPrice = await _ticketPriceRepository.UpdateTicketPrice(ticketPrice);
            return updatedTicketPrice;
        }

        public async Task DeleteTicketPrice(Guid id)
        {
            await _ticketPriceRepository.DeleteTicketPrice(id);
        }
    }
}
