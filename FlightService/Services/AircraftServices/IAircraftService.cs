using FlightService.Domain.Models;

namespace FlightService.Services.AircraftServices
{
    public interface IAircraftService
    {
        Task<List<Aircraft>> GetAllAircrafts();
        Task<Aircraft> GetAircraftById(Guid id);
        Task<Aircraft> CreateAircraft(Aircraft aircraft);
        Task<Aircraft> UpdateAircraft(Aircraft aircraft);
        Task DeleteAircraft(Guid id);
    }
}
