using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AirportRepositories;

namespace FlightService.Services.AirportServices
{
    public class AirportService: IAirportService
    {
        protected readonly IAirportRepository _airportRepository;
        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<List<Airport>> GetAllAirports()
        {
            var airports = await _airportRepository.GetAllAirports();
            return airports;
        }
        public async Task<Airport> GetAirportById(Guid id)
        {
            var airport = await _airportRepository.GetAirportById(id);
            return airport;
        }
        public async Task<Airport> CreateAirport(Airport airport)
        {
            var newAirport = await _airportRepository.CreateAirport(airport);
            return newAirport;
        }

        public async Task<Airport> UpdateAirport(Airport airport)
        {
            var updatedAirport = await _airportRepository.UpdateAirport(airport);
            return updatedAirport;
        }

        public async Task DeleteAirport(Guid id)
        {
            await _airportRepository.DeleteAirport(id);
        }
    }
}
