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
            return await _context.Rooms.Include(u=>u.Floor).FirstOrDefaultAsync(u => u.Id == id);
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
        public async Task<int> GetLastRoomNumberInHotel(Guid hotelId)
        {
            var rooms = await _context.Rooms.Where(u => u.Floor.HotelId == hotelId).OrderByDescending(u=> u.RoomNumber).ToListAsync();
            if(rooms.Count > 0)
            {
                var lastNumber = rooms.First().RoomNumber;
                return lastNumber+1;
            }
            else
            {
                return 1;
            }
        }
        public async Task<int> AvailableRoomNumber(Guid hotelId)
        {
            var availableRooms = await _context.Rooms.Where(h=> h.Floor.HotelId == hotelId && h.IsBooked == IsBooked.Available).ToListAsync();
            if (availableRooms.Count > 0)
                return availableRooms.Count;
            else
                return 1;
        }
    }
}
