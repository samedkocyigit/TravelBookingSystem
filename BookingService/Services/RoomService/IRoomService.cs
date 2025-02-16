using BookingService.Domain.Dtos;
using BookingService.Domain.Models;

namespace BookingService.Services.RoomService
{
    public interface IRoomService
    {
        Task<List<HotelDto>> GetAvailableRoomsFromHotelService();
    }
}
