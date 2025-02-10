using HotelService.Models.Models;

namespace HotelService.Infrastructure.Repositories.FacilityRepositories
{
    public interface IFacilityRepository
    {

        Task<List<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(Guid id);
        Task<Facility> CreateFacility(Facility facility);
        Task<Facility> UpdateFacility(Facility facility);
        Task DeleteFacilityById(Guid id);

    }
}
