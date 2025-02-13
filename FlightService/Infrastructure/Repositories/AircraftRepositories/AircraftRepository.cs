using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.AircraftRepositories
{
    public class AircraftRepository : IAircraftRepository
    {
        protected readonly AppDbContext _context;
        public AircraftRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aircraft>> GetAllAircrafts()
        {
            return await _context.Aircrafts.ToListAsync();
        }
        public async Task<Aircraft> GetAircraftById(Guid id)
        {
            return await _context.Aircrafts.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Aircraft> CreateAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Add(aircraft);
            await _context.SaveChangesAsync();
            return aircraft;
        }
        public async Task<Aircraft> UpdateAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Update(aircraft);
            await _context.SaveChangesAsync();
            return aircraft;
        }
        public async Task DeleteAircraft(Guid id)
        {
            var aircraft = await GetAircraftById(id);
            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();
        }
    }
}
