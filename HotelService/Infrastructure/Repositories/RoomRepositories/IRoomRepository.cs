using HotelService.Models.Models;

namespace HotelService.Infrastructure.Repositories.RoomRepositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(Guid id);
        Task<Room> CreateRoom(Room room);
        Task<Room> UpdateRoom(Room room);   
        Task DeleteRoom(Guid id);
        Task<int> AvailableRoomNumber(Guid id);
        Task<int> GetLastRoomNumberInHotel(Guid id);
    }
}
