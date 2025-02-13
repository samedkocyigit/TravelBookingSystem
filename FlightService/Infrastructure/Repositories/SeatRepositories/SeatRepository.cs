using FlightService.Domain.Models;
using FlightService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Repositories.SeatRepositories
{
    public class SeatRepository : ISeatRepository
    {
        protected readonly AppDbContext _context;
        public SeatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Seat>> GetAllSeats()
        {
            return await _context.Seats.ToListAsync();
        }
        public async Task<Seat> GetSeatById(Guid id)
        {
            return await _context.Seats.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Seat> CreateSeat(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
        public async Task<Seat> UpdateSeat(Seat seat)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
        public async Task DeleteSeat(Guid id)
        {
            var seat = await GetSeatById(id);
            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();
        }
    }
}
