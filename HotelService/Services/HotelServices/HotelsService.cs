using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.HotelRepositories;
using HotelService.Models.Models;

namespace HotelService.Services.HotelServices
{
    public class HotelsService:IHotelService
    {
        protected readonly IHotelRepository _hotelRepository;
        protected readonly IMapper _mapper;
        public HotelsService(IHotelRepository hotelRepository,IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
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
        public async Task<Hotel> CreateHotel(HotelCreationDto hotelDto)
        {
            var mappedHotel = _mapper.Map<Hotel>(hotelDto);
            var newHotel = await _hotelRepository.CreateHotel(mappedHotel);
            return newHotel;
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            var updatedHotel = await _hotelRepository.UpdateHotel(hotel);
            return updatedHotel;
        }

        public async Task DeleteHotel(Guid id)
        {
            await _hotelRepository.DeleteHotelById(id);
        }
        public async Task<List<AvailableRoomsDto>> GetAllAvailableRooms()
        {
            var availableRooms = await _hotelRepository.GetAllAvailableRooms();
            var mappedAvailableRooms = _mapper.Map<List<AvailableRoomsDto>>(availableRooms);
            foreach (var hotel in mappedAvailableRooms)
            {
                Console.WriteLine($"Hotel: {hotel.HotelName}");
                foreach (var room in hotel.Rooms)
                {
                    Console.WriteLine($"- Room Type: {room.RoomType}"); // Burada hala enum ID mi dönüyor?
                    Console.WriteLine($"- IsBooked: {room.IsBooked}");  // String mi?
                }
            }
            return mappedAvailableRooms;
        }
        public async Task AddManager(Guid id)
        {
            var hotels = await _hotelRepository.GetHotelIds();
            foreach (var hotelId in hotels)
            {
                var hotel = await _hotelRepository.GetHotelById(hotelId);
                if(hotel.ManagerIds.Contains(id))
                {
                    throw new Exception("Manager is already assigned to a hotel");
                }
                hotel.ManagerIds.Add(id);
                var updated =  await _hotelRepository.UpdateHotel(hotel);
            }
        }
    }
}
