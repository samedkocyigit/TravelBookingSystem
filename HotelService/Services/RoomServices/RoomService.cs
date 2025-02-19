using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Domain.Enums;
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

        public RoomService(IRoomRepository roomRepository,IHotelRepository hotelRepository, IFloorRepository floorRepository,IMapper mapper)
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
            mappedRoom.PricePerNight = DetermineRoomPrice(roomDto.roomType);
            mappedRoom.RoomCapacity = DetermineRoomCapacity(roomDto.roomType);
            var floor = await _floorRepository.GetFloorById(roomDto.floorId);
            mappedRoom.RoomNumber = await _roomRepository.GetLastRoomNumberInHotel(floor.HotelId);

            var newRoom = await _roomRepository.CreateRoom(mappedRoom);
            var hotel = await _hotelRepository.GetHotelById(newRoom.Floor.HotelId);
            
            if (hotel.RoomCapacity == null)
                hotel.RoomCapacity = 1;
            else
                hotel.RoomCapacity++;

            hotel.AvailableRoom = await _roomRepository.AvailableRoomNumber(hotel.Id);
            await _hotelRepository.UpdateHotel(hotel);

            return newRoom;
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var updatedRoom = await _roomRepository.UpdateRoom(room);
            return updatedRoom;
        }
        public async Task<Room> BookRoom(Guid roomId,Guid userId)
        {
            var room = await _roomRepository.GetRoomById(roomId);
            
            room.IsBooked = IsBooked.Unavailable;
            room.CurrentUserId = userId;
            var updatedRoom = await _roomRepository.UpdateRoom(room);
            var hotel = await _hotelRepository.GetHotelById(room.Floor.HotelId);
            if (hotel.AvailableRoom != null)
                hotel.AvailableRoom--;
            hotel.CustomerIds.Add(userId);
            await _hotelRepository.UpdateHotel(hotel);
            return updatedRoom;
        }

        public async Task DeleteRoom(Guid id)
        {
            var room = await _roomRepository.GetRoomById(id);
            var floor = await _floorRepository.GetFloorById(room.FloorId);
            var hotel = await _hotelRepository.GetHotelById(floor.HotelId);
            if (room.IsBooked != IsBooked.Unavailable)
            {
                if(hotel.AvailableRoom != null)
                    hotel.AvailableRoom--;
            }
            if(hotel.RoomCapacity != null)
                hotel.RoomCapacity--;

            await _hotelRepository.UpdateHotel(hotel);
            await _roomRepository.DeleteRoom(id);
        }

        private decimal DetermineRoomPrice(RoomType room)
        {
            switch (room)
            {
                case RoomType.King:
                    return 500;
                case RoomType.HoneyMoon:
                    return 450;
                case RoomType.Family:
                    return 300;
                case RoomType.Single:
                    return 180;
                default :
                    return 0;
            }
        }
        private int DetermineRoomCapacity(RoomType room)
        {
            switch (room)
            {
                case RoomType.King:
                    return 5;
                case RoomType.HoneyMoon:
                    return 2;
                case RoomType.Family:
                    return 3;
                case RoomType.Single:
                    return 1;
                default:
                    return 0;
            }
        }

    }
}
