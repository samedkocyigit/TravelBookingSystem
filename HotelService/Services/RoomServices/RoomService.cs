using HotelService.Infrastructure.Repositories.RoomRepositories;
using HotelService.Models.Models;

namespace HotelService.Services.RoomServices
{
    public class RoomService:IRoomService
    {
        protected readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
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
        public async Task<Room> CreateRoom(Room room)
        {
            var newRoom = await _roomRepository.CreateRoom(room);
            return newRoom;
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var updatedRoom = await _roomRepository.UpdateRoom(room);
            return updatedRoom;
        }

        public async Task DeleteRoom(Guid id)
        {
            await _roomRepository.GetRoomById(id);
        }
    }
}
