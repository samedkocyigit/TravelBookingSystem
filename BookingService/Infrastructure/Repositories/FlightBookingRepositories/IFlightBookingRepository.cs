using BookingService.Domain.Models;

namespace BookingService.Infrastructure.Repositories.FlightBookingRepositories
{
    public interface IFlightBookingRepository
    {
        Task<List<FlightBooking>> GetAllBookings();
        Task<FlightBooking> GetBookingById(Guid id);
        Task<FlightBooking> CreateBooking(FlightBooking booking);
        Task<FlightBooking> UpdateBooking(FlightBooking booking);
        Task DeleteBooking(Guid id);
    }
}
