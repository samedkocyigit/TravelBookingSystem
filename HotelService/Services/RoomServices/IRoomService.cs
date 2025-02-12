using HotelService.Domain.Dtos;
using HotelService.Models.Models;

namespace HotelService.Services.RoomServices
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();
        Task<Room>  GetRoomById(Guid id);
        Task<Room>  CreateRoom(RoomCreationDto roomDto);
        Task<Room> UpdateRoom(Room room);
        Task DeleteRoom(Guid id);
    }
}
