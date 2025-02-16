using HotelService.Domain.Dtos;
using HotelService.Models.Models;

namespace HotelService.Services.HotelServices
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<List<AvailableRoomsDto>> GetAllAvailableRooms();
        Task<Hotel> GetHotelById(Guid id);
        Task<Hotel> CreateHotel(HotelCreationDto hotel);
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task AddManager(Guid id);
        Task DeleteHotel(Guid id);
    }
}
