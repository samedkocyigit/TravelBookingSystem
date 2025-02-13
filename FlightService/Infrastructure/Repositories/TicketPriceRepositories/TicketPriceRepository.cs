using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.TicketPriceRepositories
{
    public class TicketPriceRepository : ITicketPriceRepository
    {
        protected readonly AppDbContext _context;
        public TicketPriceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TicketPrice>> GetAllTicketPrices()
        {
            return await _context.TicketPrices.ToListAsync();
        }
        public async Task<TicketPrice> GetTicketPriceById(Guid id)
        {
            return await _context.TicketPrices.FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<TicketPrice> CreateTicketPrice(TicketPrice ticketPrice)
        {
            _context.TicketPrices.Add(ticketPrice);
            await _context.SaveChangesAsync();
            return ticketPrice;
        }
        public async Task<TicketPrice> UpdateTicketPrice(TicketPrice ticketPrice)
        {
            _context.TicketPrices.Update(ticketPrice);
            await _context.SaveChangesAsync();
            return ticketPrice;
        }
        public async Task DeleteTicketPrice(Guid id)
        {
            var ticketPrice = await GetTicketPriceById(id);
            _context.TicketPrices.Remove(ticketPrice);
            await _context.SaveChangesAsync();
        }
    }
}
