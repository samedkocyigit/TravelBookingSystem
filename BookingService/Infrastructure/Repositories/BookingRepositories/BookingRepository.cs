using BookingService.Domain.Models;
using BookingService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Repositories.BookingRepositories
{
    public class BookingRepository:IBookingRepository
    {
        protected readonly AppDbContext _context;
        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }
        public async Task<Booking?> GetBookingById(Guid id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<Booking> UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task DeleteBooking(Guid id)
        {
            var booking = await GetBookingById(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
