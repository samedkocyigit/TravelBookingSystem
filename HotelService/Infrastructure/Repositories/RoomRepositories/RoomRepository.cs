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
    }
}
