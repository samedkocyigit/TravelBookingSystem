using FlightService.Domain.Models;

namespace FlightService.Services.AirportServices
{
    public interface IAirportService
    {
        Task<List<Airport>> GetAllAirports();
        Task<Airport> GetAirportById(Guid id);
        Task<Airport> CreateAirport(Airport airport);
        Task<Airport> UpdateAirport(Airport airport);
        Task DeleteAirport(Guid id);
    }
}
