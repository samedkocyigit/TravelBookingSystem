using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories
{
    public class FlightCompanyRepository : IFlightCompanyRepository
    {
        protected readonly AppDbContext _context;
        public FlightCompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FlightCompany>> GetAllFlightCompanies()
        {
            return await _context.FlightCompanies.ToListAsync();
        }
        public async Task<FlightCompany> GetFlightCompanyById(Guid id)
        {
            return await _context.FlightCompanies.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<FlightCompany> CreateFlightCompany(FlightCompany flightCompany)
        {
            _context.FlightCompanies.Add(flightCompany);
            await _context.SaveChangesAsync();
            return flightCompany;
        }
        public async Task<FlightCompany> UpdateFlightCompany(FlightCompany flightCompany)
        {
            _context.FlightCompanies.Update(flightCompany);
            await _context.SaveChangesAsync();
            return flightCompany;
        }
        public async Task DeleteFlightCompany(Guid id)
        {
            var flightCompany = await GetFlightCompanyById(id);
            _context.FlightCompanies.Remove(flightCompany);
            await _context.SaveChangesAsync();
        }
    }
}
