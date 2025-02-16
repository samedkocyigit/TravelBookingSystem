using FlightService.Domain.Dtos.Airport;
using FlightService.Domain.Models;

namespace FlightService.Services.AirportServices
{
    public interface IAirportService
    {
        Task<List<AirportResponseDto>> GetAllAirports();
        Task<AirportResponseDto> GetAirportById(Guid id);
        Task<AirportResponseDto> CreateAirport(CreateAirportDto airportDto);
        Task<AirportResponseDto> UpdateAirport(CreateAirportDto airportDto);
        Task DeleteAirport(Guid id);
    }
}
