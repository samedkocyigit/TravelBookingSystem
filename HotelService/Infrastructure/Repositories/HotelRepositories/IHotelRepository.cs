using HotelService.Models.Models;

namespace HotelService.Infrastructure.Repositories.HotelRepositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        Task<List<Hotel>> GetAllAvailableRooms();
        Task<Hotel> GetHotelById(Guid id);
        Task<Hotel> CreateHotel(Hotel hotel);   
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task DeleteHotelById(Guid id);
    }
}
