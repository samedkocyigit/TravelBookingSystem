using BookingService.Domain.Models;

namespace BookingService.Infrastructure.Repositories.BookingRepositories
{
    public interface IBookingRepository
    {
       Task<List<Booking>> GetAllBookings();
        Task<Booking> GetBookingById(Guid id);
        Task<Booking> CreateBooking(Booking booking);
        Task<Booking> UpdateBooking(Booking booking);   
        Task DeleteBooking(Guid id);
    }
}
