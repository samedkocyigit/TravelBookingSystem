using HotelService.Models.Models;

namespace HotelService.Infrastructure.Repositories.HotelRepositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(Guid id);
        Task<Hotel> GetHotelByName(string name);
        Task<Hotel> CreateHotel(Hotel hotel);   
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task<Hotel> DeleteHotelById(int id);
    }
}
