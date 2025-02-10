using FlightService.Domain.Models;

namespace FlightService.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightById(Guid id);
        Task<Flight> CreateFlight(Flight flight);
        Task<Flight> UpdateFlight(Flight flight);
        Task DeleteFlight(Guid id);
    }
}
