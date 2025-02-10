using HotelService.Infrastructure.ApplicationDbContext;
using HotelService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.Repositories.FacilityRepositories
{
    public class FacilityRepository:IFacilityRepository
    {
        protected readonly AppDbContext _context;
        public FacilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Facility>> GetAllFacilities()
        {
            return await _context.Facilities.ToListAsync();
        }
        public async Task<Facility> GetFacilityById(Guid id)
        {
            return await _context.Facilities.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Facility> CreateFacility(Facility facility)
        {
            _context.Facilities.Add(facility);
            await _context.SaveChangesAsync();
            return facility;
        }
        public async Task<Facility> UpdateFacility(Facility facility)
        {
            _context.Facilities.Update(facility);
            await _context.SaveChangesAsync();
            return facility;
        }
        public async Task DeleteFacilityById(Guid id)
        {
            var facility = await GetFacilityById(id);
            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();
        }
    }
}
