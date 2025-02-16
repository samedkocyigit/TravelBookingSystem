using BookingService.Domain.Models;
using BookingService.Infrastructure.Repositories.FlightBookingRepositories;

namespace BookingService.Services.FlightBookingServices
{
    public class FlightBookingsService:IFlightBookingServices
    {
        protected readonly IFlightBookingRepository _bookingRepository;
        public FlightBookingsService(IFlightBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<List<FlightBooking>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookings();
            return bookings;
        }
        public async Task<FlightBooking> GetBookingById(Guid id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return booking;
        }
        public async Task<FlightBooking> CreateBooking(FlightBooking booking)
        {
            var newBooking = await _bookingRepository.CreateBooking(booking);
            return newBooking;
        }
        public async Task<FlightBooking> UpdateBooking(FlightBooking booking)
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
