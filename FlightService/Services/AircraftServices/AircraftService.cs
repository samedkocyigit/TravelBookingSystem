using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AircraftRepositories;

namespace FlightService.Services.AircraftServices
{
    public class AircraftService: IAircraftService
    {
        protected readonly IAircraftRepository _aircraftRepository;
        public AircraftService(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        public async Task<List<Aircraft>> GetAllAircrafts()
        {
            var aircrafts = await _aircraftRepository.GetAllAircrafts();
            return aircrafts;
        }
        public async Task<Aircraft> GetAircraftById(Guid id)
        {
            var aircraft = await _aircraftRepository.GetAircraftById(id);
            return aircraft;
        }
        public async Task<Aircraft> CreateAircraft(Aircraft aircraft)
        {
            var newAircraft = await _aircraftRepository.CreateAircraft(aircraft);
            return newAircraft;
        }

        public async Task<Aircraft> UpdateAircraft(Aircraft aircraft)
        {
            var updatedAircraft = await _aircraftRepository.UpdateAircraft(aircraft);
            return updatedAircraft;
        }

        public async Task DeleteAircraft(Guid id)
        {
            await _aircraftRepository.DeleteAircraft(id);
        }
    }
}
