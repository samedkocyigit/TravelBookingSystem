using BookingService.Domain.Models;
using BookingService.Infrastructure.Repositories.HotelBookingRepositories;

namespace BookingService.Services.HotelBookingServices
{
    public class HotelBookingsService:IHotelBookingServices
    {
        protected readonly IHotelBookingRepository _bookingRepository;
        public HotelBookingsService(IHotelBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<List<HotelBooking>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookings();
            return bookings;
        }
        public async Task<HotelBooking> GetBookingById(Guid id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return booking;
        }
        public async Task<HotelBooking> CreateBooking(HotelBooking booking)
        {
            var newBooking = await _bookingRepository.CreateBooking(booking);
            return newBooking;
        }
        public async Task<HotelBooking> UpdateBooking(HotelBooking booking)
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
