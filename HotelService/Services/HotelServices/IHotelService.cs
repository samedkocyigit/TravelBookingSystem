using HotelService.Domain.Dtos;
using HotelService.Models.Models;

namespace HotelService.Services.HotelServices
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(Guid id);
        Task<Hotel> CreateHotel(HotelCreationDto hotelDto);
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task DeleteHotel(Guid id);
    }
}
