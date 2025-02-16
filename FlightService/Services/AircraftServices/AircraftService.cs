using AutoMapper;
using FlightService.Domain.Dtos.Aircraft;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AircraftRepositories;

namespace FlightService.Services.AircraftServices
{
    public class AircraftService: IAircraftService
    {
        protected readonly IAircraftRepository _aircraftRepository;
        protected readonly IMapper _mapper;
        public AircraftService(IAircraftRepository aircraftRepository , IMapper mapper)
        {
            _aircraftRepository = aircraftRepository;
            _mapper = mapper;
        }

        public async Task<List<AircraftResponseDto>> GetAllAircrafts()
        {
            var aircrafts = await _aircraftRepository.GetAllAircrafts();
            var mappedAircrafts = _mapper.Map<List<AircraftResponseDto>>(aircrafts);
            return mappedAircrafts;
        }
        public async Task<AircraftResponseDto> GetAircraftById(Guid id)
        {
            var aircraft = await _aircraftRepository.GetAircraftById(id);
            var mappedAircraft = _mapper.Map<AircraftResponseDto>(aircraft);
            return mappedAircraft;
        }
        public async Task<AircraftResponseDto> CreateAircraft(CreateAircraftDto aircraftDto)
        {
            var aircraft = _mapper.Map<Aircraft>(aircraftDto);
            var newAircraft = await _aircraftRepository.CreateAircraft(aircraft);
            var mappedAircraft = _mapper.Map<AircraftResponseDto>(newAircraft);
            return mappedAircraft;
        }

        public async Task<AircraftResponseDto> UpdateAircraft(CreateAircraftDto aircraftDto)
        {
            var aircraft = _mapper.Map<Aircraft>(aircraftDto);
            var updatedAircraft = await _aircraftRepository.UpdateAircraft(aircraft);
            var mappedAircraft = _mapper.Map<AircraftResponseDto>(updatedAircraft);
            return mappedAircraft;
        }

        public async Task DeleteAircraft(Guid id)
        {
            await _aircraftRepository.DeleteAircraft(id);
        }
    }
}
