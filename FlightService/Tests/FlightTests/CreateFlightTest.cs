using AutoMapper;
using FlightService.Domain.Dtos.Flight;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AircraftRepositories;
using FlightService.Infrastructure.Repositories.AirportRepositories;
using FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories;
using FlightService.Infrastructure.Repositories.FlightRepositories;
using FlightService.Services.FlightServices;
using Moq;
using Xunit;

namespace FlightService.Tests.FlightTests
{
    public class FlightServiceTests
    {
        private readonly Mock<IFlightRepository> _flightRepository;
        private readonly Mock<IFlightCompanyRepository> _flightCompanyRepository;
        private readonly Mock<IAircraftRepository> _aircraftRepository;
        private readonly Mock<IAirportRepository> _airportRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IFlightService _flightService;

        public FlightServiceTests()
        {
            _flightRepository = new Mock<IFlightRepository>();
            _flightCompanyRepository = new Mock<IFlightCompanyRepository>();
            _aircraftRepository = new Mock<IAircraftRepository>();
            _airportRepository = new Mock<IAirportRepository>();
            _mapper = new Mock<IMapper>();

            _flightService = new FlightsService(_flightRepository.Object,
                                                _airportRepository.Object,
                                                _aircraftRepository.Object,
                                                _flightCompanyRepository.Object,
                                                _mapper.Object);
        }

        [Fact]
        public async Task Should_CreateFlight_When_ValidCreateFlightDtoIsPassed()
        {
            var createFlightDto = new CreateFlightDto
            {
                FlightCompanyId = Guid.NewGuid(),
                AircraftId = Guid.NewGuid(),
                OriginAirportId = Guid.NewGuid(),
                DestinationAirportId = Guid.NewGuid(),
                DepartureTime = DateTime.UtcNow,
                ArrivalTime = DateTime.UtcNow.AddHours(3)
            };

            var flight = new Flight
            {
                Id = Guid.NewGuid(),
                FlightCompanyId = createFlightDto.FlightCompanyId,
                AircraftId = createFlightDto.AircraftId,
                OriginAirportId = createFlightDto.OriginAirportId,
                DestinationAirportId = createFlightDto.DestinationAirportId
            };

            var flightCompany = new FlightCompany { Id = createFlightDto.FlightCompanyId, Flights = new List<Flight>() };
            var aircraft = new Aircraft { Id = createFlightDto.AircraftId, Flights = new List<Flight>() };
            var originAirport = new Airport { Id = createFlightDto.OriginAirportId, DepartingFlights = new List<Flight>() };
            var destinationAirport = new Airport { Id = createFlightDto.DestinationAirportId, ArrivingFlights = new List<Flight>() };

            var flightResponseDto = new FlightResponseDto { Id = flight.Id };

            _mapper.Setup(m => m.Map<Flight>(createFlightDto)).Returns(flight);

            _flightCompanyRepository.Setup(r => r.GetFlightCompanyById(createFlightDto.FlightCompanyId))
                                    .ReturnsAsync(flightCompany);
            _aircraftRepository.Setup(r => r.GetAircraftById(createFlightDto.AircraftId))
                               .ReturnsAsync(aircraft);
            _airportRepository.Setup(r => r.GetAirportById(createFlightDto.OriginAirportId))
                              .ReturnsAsync(originAirport);
            _airportRepository.Setup(r => r.GetAirportById(createFlightDto.DestinationAirportId))
                              .ReturnsAsync(destinationAirport);

            _flightRepository.Setup(r => r.CreateFlight(It.IsAny<Flight>())).ReturnsAsync(flight);

            _mapper.Setup(m => m.Map<FlightResponseDto>(flight)).Returns(flightResponseDto);

            var result = await _flightService.CreateFlight(createFlightDto);

            Assert.NotNull(result);
            Assert.Equal(flightResponseDto.Id, result.Id);

            _flightCompanyRepository.Verify(r => r.UpdateFlightCompany(flightCompany), Times.Once);
            _aircraftRepository.Verify(r => r.UpdateAircraft(aircraft), Times.Once);
            _airportRepository.Verify(r => r.UpdateAirport(originAirport), Times.Once);
            _airportRepository.Verify(r => r.UpdateAirport(destinationAirport), Times.Once);
        }
    }
}
