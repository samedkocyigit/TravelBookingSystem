using AutoMapper;
using FlightService.Domain.Dtos.Airport;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AirportRepositories;

namespace FlightService.Services.AirportServices
{
    public class AirportService: IAirportService
    {
        protected readonly IAirportRepository _airportRepository;
        protected readonly IMapper _mapper;
        public AirportService(IAirportRepository airportRepository , IMapper mapper)
        {
            _mapper = mapper;
            _airportRepository = airportRepository;
        }

        public async Task<List<AirportResponseDto>> GetAllAirports()
        {
            var airports = await _airportRepository.GetAllAirports();
            var mappedAirports = _mapper.Map<List<AirportResponseDto>>(airports);
            return mappedAirports;
        }
        public async Task<AirportResponseDto> GetAirportById(Guid id)
        {
            var airport = await _airportRepository.GetAirportById(id);
            var mappedAirport = _mapper.Map<AirportResponseDto>(airport);
            return mappedAirport;
        }
        public async Task<AirportResponseDto> CreateAirport(CreateAirportDto airportDto)
        {
            var airport = _mapper.Map<Airport>(airportDto);
            var newAirport = await _airportRepository.CreateAirport(airport);
            var mappedAirport = _mapper.Map<AirportResponseDto>(newAirport);
            return mappedAirport;
        }

        public async Task<AirportResponseDto> UpdateAirport(CreateAirportDto airportDto)
        {
            var airport = _mapper.Map<Airport>(airportDto);
            var updatedAirport = await _airportRepository.UpdateAirport(airport);
            var mappedAirport = _mapper.Map<AirportResponseDto>(updatedAirport);
            return mappedAirport;
        }

        public async Task DeleteAirport(Guid id)
        {
            await _airportRepository.DeleteAirport(id);
        }
    }
}
