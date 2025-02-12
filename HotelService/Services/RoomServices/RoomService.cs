using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.FloorRepositories;
using HotelService.Infrastructure.Repositories.HotelRepositories;
using HotelService.Infrastructure.Repositories.RoomRepositories;
using HotelService.Models.Enums;
using HotelService.Models.Models;

namespace HotelService.Services.RoomServices
{
    public class RoomService:IRoomService
    {
        protected readonly IRoomRepository _roomRepository;
        protected readonly IHotelRepository _hotelRepository;
        protected readonly IFloorRepository _floorRepository;
        protected readonly IMapper _mapper;
        public RoomService(IRoomRepository roomRepository,IHotelRepository hotelRepository,IFloorRepository floorRepository,IMapper mapper)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var rooms = await _roomRepository.GetAllRooms();
            return rooms;
        }
        public async Task<Room> GetRoomById(Guid id)
        {
            var room = await _roomRepository.GetRoomById(id);
            return room;
        }
        public async Task<Room> CreateRoom(RoomCreationDto roomDto)
        {
            var mappedRoom = _mapper.Map<Room>(roomDto);
            mappedRoom.PricePerNight = determineRoomPrice(roomDto.roomType);
            mappedRoom.RoomCapacity = determineRoomCapacity(roomDto.roomType);

            var floor = await _floorRepository.GetFloorById(roomDto.floorId);
            var hotel = await _hotelRepository.GetHotelById(floor.HotelId);
            
            mappedRoom.RoomNumber = await _roomRepository.GetLastRoomNumber(hotel.Id);
            var newRoom = await _roomRepository.CreateRoom(mappedRoom);
            var availableRoomCapacity = await _roomRepository.AllRoomsAvailable(hotel.Id);

            if (hotel.AvailableRoom == null)
                hotel.AvailableRoom = 1;
            else hotel.AvailableRoom = availableRoomCapacity;

            if (hotel.RoomCapacity == null)
                hotel.RoomCapacity = 1;
            else
                hotel.RoomCapacity++;

            var updatedHotel = await _hotelRepository.UpdateHotel(hotel);
            
            return newRoom;
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var updatedRoom = await _roomRepository.UpdateRoom(room);
            return updatedRoom;
        }

        public async Task DeleteRoom(Guid id)
        {
            await _roomRepository.DeleteRoom(id);

        }

        private decimal determineRoomPrice(RoomType roomType)
        {
            
            switch(roomType)
            {
                case RoomType.King:
                    return 400;
                case RoomType.Family:
                    return 250;
                case RoomType.Single:
                    return 150;
                case RoomType.HoneyMoon:
                    return 300;
                default:
                    return 0;
            }
        }
        private int determineRoomCapacity(RoomType roomType)
        {
            switch(roomType)
            {
                case RoomType.King:
                    return 5;
                case RoomType.Family:
                    return 4;
                case RoomType.Single:
                    return 1;
                case RoomType.HoneyMoon:
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
