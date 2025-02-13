using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.AirportRepositories
{
    public class AirportRepository : IAirportRepository
    {
        protected readonly AppDbContext _context;
        public AirportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Airport>> GetAllAirports()
        {
            return await _context.Airports.ToListAsync();
        }
        public async Task<Airport> GetAirportById(Guid id)
        {
            return await _context.Airports.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Airport> CreateAirport(Airport airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();
            return airport;
        }
        public async Task<Airport> UpdateAirport(Airport airport)
        {
            _context.Airports.Update(airport);
            await _context.SaveChangesAsync();
            return airport;
        }
        public async Task DeleteAirport(Guid id)
        {
            var airport = await GetAirportById(id);
            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
        }
    }
}
