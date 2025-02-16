using BookingService.Domain.Models;

namespace BookingService.Services.FlightBookingServices
{
    public interface IFlightBookingServices
    {
        Task<List<FlightBooking>> GetAllBookings();
        Task<FlightBooking> GetBookingById(Guid id);
        Task<FlightBooking> CreateBooking(FlightBooking booking);
        Task<FlightBooking> UpdateBooking(FlightBooking booking);
        Task DeleteBooking(Guid id);
    }
}
