using HotelService.Infrastructure.ApplicationDbContext;
using HotelService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.Repositories.FloorRepositories
{
    public class FloorRepository:IFloorRepository
    {
        protected readonly AppDbContext _context;
        public FloorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Floor>> GetAllFloors()
        {
            return await _context.Floors.Include(f=> f.Rooms).Include(f=>f.Facilities).ToListAsync();
        }
        public async Task<Floor> GetFloorById(Guid id)
        {
            return await _context.Floors.Include(f => f.Rooms).Include(f => f.Facilities).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Floor> CreateFloor(Floor floor)
        {
            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();
            return floor;
        }
        public async Task<Floor> UpdateFloor(Floor floor)
        {
            _context.Floors.Update(floor);
            await _context.SaveChangesAsync();
            return floor;
        }
        public async Task DeleteFloorById(Guid id)
        {
            var floor = await GetFloorById(id);
            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();
        }
    }
}
