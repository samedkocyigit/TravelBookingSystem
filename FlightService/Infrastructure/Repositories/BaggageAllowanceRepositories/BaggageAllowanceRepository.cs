using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.BaggageAllowanceRepositories
{
    public class BaggageAllowanceRepository : IBaggageAllowanceRepository
    {
        protected readonly AppDbContext _context;
        public BaggageAllowanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BaggageAllowance>> GetAllBaggageAllowances()
        {
            return await _context.BaggageAllowances.ToListAsync();
        }
        public async Task<BaggageAllowance> GetBaggageAllowanceById(Guid id)
        {
            return await _context.BaggageAllowances.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<BaggageAllowance> CreateBaggageAllowance(BaggageAllowance baggageAllowance)
        {
            _context.BaggageAllowances.Add(baggageAllowance);
            await _context.SaveChangesAsync();
            return baggageAllowance;
        }
        public async Task<BaggageAllowance> UpdateBaggageAllowance(BaggageAllowance baggageAllowance)
        {
            _context.BaggageAllowances.Update(baggageAllowance);
            await _context.SaveChangesAsync();
            return baggageAllowance;
        }
        public async Task DeleteBaggageAllowance(Guid id)
        {
            var baggageAllowance = await GetBaggageAllowanceById(id);
            _context.BaggageAllowances.Remove(baggageAllowance);
            await _context.SaveChangesAsync();
        }
    }
}
