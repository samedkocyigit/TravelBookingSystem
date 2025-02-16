using BookingService.Domain.Models;
using BookingService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Repositories.FlightBookingRepositories
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        protected readonly AppDbContext _context;
        public FlightBookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FlightBooking>> GetAllBookings()
        {
            return await _context.FlightBookings.ToListAsync();
        }
        public async Task<FlightBooking> GetBookingById(Guid id)
        {
            return await _context.FlightBookings.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<FlightBooking> CreateBooking(FlightBooking booking)
        {
            _context.FlightBookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<FlightBooking> UpdateBooking(FlightBooking booking)
        {
            _context.FlightBookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task DeleteBooking(Guid id)
        {
            var booking = await GetBookingById(id);
            _context.FlightBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
