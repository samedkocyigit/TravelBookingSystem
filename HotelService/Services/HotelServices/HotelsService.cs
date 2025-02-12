using HotelService.Infrastructure.Repositories.HotelRepositories;
using HotelService.Models.Models;

namespace HotelService.Services.HotelServices
{
    public class HotelsService:IHotelService
    {
        protected readonly IHotelRepository _hotelRepository;
        public HotelsService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAllHotels();
            return hotels;
        }
        public async Task<Hotel> GetHotelById(Guid id)
        {
            var hotel = await _hotelRepository.GetHotelById(id);
            return hotel;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            var newHotel = await _hotelRepository.CreateHotel(hotel);
            return newHotel;
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            var updatedHotel = await _hotelRepository.UpdateHotel(hotel);
            return updatedHotel;
        }

        public async Task DeleteHotel(Guid id)
        {
            await _hotelRepository.GetHotelById(id);
        }
    }
}
