using BookingService.Domain.Models;
using BookingService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Repositories.HotelBookingRepositories
{
    public class HotelBookingRepository:IHotelBookingRepository
    {
        protected readonly AppDbContext _context;
        public HotelBookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelBooking>> GetAllBookings()
        {
            return await _context.HotelBookings.ToListAsync();
        }
        public async Task<HotelBooking> GetBookingById(Guid id)
        {
            return await _context.HotelBookings.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<HotelBooking> CreateBooking(HotelBooking booking)
        {
            _context.HotelBookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<HotelBooking> UpdateBooking(HotelBooking booking)
        {
            _context.HotelBookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task DeleteBooking(Guid id)
        {
            var booking = await GetBookingById(id);
            _context.HotelBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
