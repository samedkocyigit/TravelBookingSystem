using HotelService.Domain.Enums;
using HotelService.Infrastructure.ApplicationDbContext;
using HotelService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.Repositories.RoomRepositories
{
    public class RoomRepository:IRoomRepository
    {
        protected readonly AppDbContext _context;
        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomById(Guid id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Room> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<Room> UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task DeleteRoom(Guid id)
        {
            var room = await GetRoomById(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetLastRoomNumber(Guid hotelId)
        {
            var rooms = _context.Rooms.Where(r=> r.Floor.HotelId == hotelId).OrderByDescending(r => r.RoomNumber).ToList();
            if (rooms.Count > 0)
            {
                var higestRoomNumber = rooms.ToList().FirstOrDefault();
                var roomNumber = higestRoomNumber.RoomNumber == null ? 1 : higestRoomNumber.RoomNumber++;
                return roomNumber;
            }
            else
            {
                var roomNumber = 1;
                return roomNumber;
            }
        }
        public async Task<int> AllRoomsAvailable(Guid hotelId)
        {
            var availableRooms = await _context.Rooms.Where(h => h.Floor.Hotel.Id == hotelId && h.IsBooked == IsBooked.Available).ToListAsync();
            var availabeRoomCounter = availableRooms.Count;
            return availabeRoomCounter;
        }
    }
}
