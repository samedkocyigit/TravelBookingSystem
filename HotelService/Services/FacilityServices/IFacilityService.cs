using HotelService.Domain.Dtos;
using HotelService.Models.Models;

namespace HotelService.Services.FacilityServices
{
    public interface IFacilityService
    {
        Task<List<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(Guid id);
        Task<Facility> CreateFacility(FacilityCreationDto facilityDto);
        Task<Facility> UpdateFacility(Facility facility);
        Task DeleteFacility(Guid id);
    }
}
