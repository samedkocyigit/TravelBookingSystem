using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.FlightRepository;

namespace FlightService.Services.FlightServices
{
    public class FlightsService: IFlightService
    {
        protected readonly IFlightRepository _flightRepository;
        public FlightsService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlights();
            return flights;
        }
        public async Task<Flight> GetFlightById(Guid id)
        {
            var flight = await _flightRepository.GetFlightById(id);
            return flight;
        }
        public async Task<Flight> CreateFlight(Flight flight)
        {
            var newFlight = await _flightRepository.CreateFlight(flight);
            return newFlight;
        }

        public async Task<Flight> UpdateFlight(Flight flight)
        {
            var updatedFlight = await _flightRepository.UpdateFlight(flight);
            return updatedFlight;
        }

        public async Task DeleteFlight(Guid id)
        {
            await _flightRepository.GetFlightById(id);
        }
    }
}
