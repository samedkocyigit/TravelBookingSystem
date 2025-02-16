using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.AircraftRepositories
{
    public interface IAircraftRepository
    {
        Task<List<Aircraft>> GetAllAircrafts();
        Task<Aircraft> GetAircraftById(Guid id);
        Task<Aircraft> CreateAircraft(Aircraft aircraft);
        Task<Aircraft> UpdateAircraft(Aircraft aircraft);
        Task DeleteAircraft(Guid id);
    }
}
