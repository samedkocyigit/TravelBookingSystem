using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.FlightRepository
{
    public class FlightRepository:IFlightRepository
    {
        protected readonly AppDbContext _context;
        public FlightRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            return await _context.Flights.ToListAsync();
        }
        public async Task<Flight> GetFlightById(Guid id)
        {
            return await _context.Flights.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Flight> CreateFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            return flight;
        }
        public async Task<Flight> UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
            return flight;
        }
        public async Task DeleteFlight(Guid id)
        {
            var flight = await GetFlightById(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }
    }
}
