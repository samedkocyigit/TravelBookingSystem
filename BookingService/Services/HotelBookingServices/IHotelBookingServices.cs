using BookingService.Domain.Models;

namespace BookingService.Services.HotelBookingServices
{
    public interface IHotelBookingServices
    {
        Task<List<HotelBooking>> GetAllBookings();
        Task<HotelBooking> GetBookingById(Guid id);
        Task<HotelBooking> CreateBooking(HotelBooking booking);
        Task<HotelBooking> UpdateBooking(HotelBooking booking);
        Task DeleteBooking(Guid id);
    }
}
