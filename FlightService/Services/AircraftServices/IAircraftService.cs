using FlightService.Domain.Dtos.Aircraft;
using FlightService.Domain.Models;

namespace FlightService.Services.AircraftServices
{
    public interface IAircraftService
    {
        Task<List<AircraftResponseDto>> GetAllAircrafts();
        Task<AircraftResponseDto> GetAircraftById(Guid id);
        Task<AircraftResponseDto> CreateAircraft(CreateAircraftDto aircraftDto);
        Task<AircraftResponseDto> UpdateAircraft(CreateAircraftDto aircraftDto);
        Task DeleteAircraft(Guid id);
    }
}
