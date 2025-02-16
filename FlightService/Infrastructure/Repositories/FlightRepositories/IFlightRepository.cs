using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.FlightRepositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightById(Guid id);
        Task<Flight> CreateFlight(Flight flight);
        Task<Flight> UpdateFlight(Flight flight);
        Task DeleteFlight(Guid id);
    }
}
