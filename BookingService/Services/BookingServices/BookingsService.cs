using BookingService.Domain.Models;
using BookingService.Infrastructure.Repositories.BookingRepositories;

namespace BookingService.Services.BookingServices
{
    public class BookingsService:IBookingServices
    {
        protected readonly IBookingRepository _bookingRepository;
        public BookingsService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<List<Booking>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookings();
            return bookings;
        }
        public async Task<Booking> GetBookingById(Guid id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return booking;
        }
        public async Task<Booking> CreateBooking(Booking booking)
        {
            var newBooking = await _bookingRepository.CreateBooking(booking);
            return newBooking;
        }
        public async Task<Booking> UpdateBooking(Booking booking)
        {
            var updatedBooking = await _bookingRepository.UpdateBooking(booking);
            return updatedBooking;
        }

        public async Task DeleteBooking(Guid id)
        {
            await _bookingRepository.DeleteBooking(id);
        }

        
    }
}
