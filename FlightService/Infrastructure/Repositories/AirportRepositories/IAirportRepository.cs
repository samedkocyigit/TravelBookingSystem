using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.AirportRepositories
{
    public interface IAirportRepository
    {
        Task<List<Airport>> GetAllAirports();
        Task<Airport> GetAirportById(Guid id);
        Task<Airport> CreateAirport(Airport airport);
        Task<Airport> UpdateAirport(Airport airport);
        Task DeleteAirport(Guid id);
    }
}
