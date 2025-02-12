using HotelService.Infrastructure.ApplicationDbContext;
using HotelService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.Repositories.HotelRepositories
{
    public class HotelRepository:IHotelRepository
    {
        protected readonly AppDbContext _context;
        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _context.Hotels
                .Include(h=> h.Floors)
                    .ThenInclude(h=> h.Rooms)
                .Include(h=>h.Floors)
                    .ThenInclude(h=>h.Facilities)
                .ToListAsync();
        }
        public async Task<Hotel> GetHotelById(Guid id)
        {
            return await _context.Hotels
                .Include(h=> h.Floors)
                    .ThenInclude(h=>h.Rooms)
                .Include(h=> h.Floors)
                    .ThenInclude(h=>h.Facilities)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task DeleteHotelById(Guid id)
        {
            var hotel = await GetHotelById(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
