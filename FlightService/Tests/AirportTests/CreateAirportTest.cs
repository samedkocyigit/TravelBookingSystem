using AutoMapper;
using FlightService.Domain.Dtos.Aircraft;
using FlightService.Domain.Dtos.Airport;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AirportRepositories;
using FlightService.Services.AirportServices;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FlightService.Tests.AirportTests
{
    public class CreateAirportTest
    {
        protected readonly Mock<IAirportRepository> _airportRepository;
        protected readonly IAirportService _airportService;
        protected readonly Mock<IMapper> _mapper;

        public CreateAirportTest()
        {
            _mapper = new Mock<IMapper>();
            _airportRepository = new Mock<IAirportRepository>();
            _airportService = new AirportService(_airportRepository.Object,_mapper.Object);
        }

        [Fact]
        public async Task ShouldCreate_Airport_When_CreateAirpotDto_IsValid()
        {
            var airportDto = new CreateAirportDto
            {
                Name = "test",
                IATACode = "tt",
                Location = "testLocation"
            };

            var airport = new Airport
            {
                Id = Guid.NewGuid(),
                Name = airportDto.Name,
                IATACode = airportDto.IATACode,
                Location = airportDto.Location
            };

            var responseDto = new AirportResponseDto
            {
                Id = airport.Id,
                Name = airport.Name,
                IATACode = airport.IATACode,
                Location = airport.Location
            };

            _mapper.Setup(m => m.Map<Airport>(airportDto)).Returns(airport);
            _mapper.Setup(m => m.Map<AirportResponseDto>(airport)).Returns(responseDto);

            _airportRepository.Setup(x => x.CreateAirport(It.IsAny<Airport>()))
                               .ReturnsAsync(airport);

            var result = await _airportService.CreateAirport(airportDto);
            Assert.NotNull(result);
            Assert.Equal(responseDto.Id, result.Id);
            Assert.Equal(responseDto.Name, result.Name);
            Assert.Equal(responseDto.IATACode, result.IATACode);
            Assert.Equal(responseDto.Location, result.Location);
          
        }
        [Fact]
        public async Task ShouldThrowExpection_IsAirportDto_IsInvalid()
        {
            var airportDto = new CreateAirportDto
            {
                Name = "",
                IATACode = "",
                Location = ""
            };
            
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _airportService.CreateAirport(airportDto));

            Assert.NotNull(exception);
            Assert.IsType<ValidationException>(exception);
            Assert.Equal("Name, IATACode and Location are required.", exception.Message);

            _airportRepository.Verify(r => r.CreateAirport(It.IsAny<Airport>()), Times.Never);  
            _mapper.Verify(m => m.Map<Airport>(airportDto), Times.Never);
            _mapper.Verify(m => m.Map<AirportResponseDto>(It.IsAny<Airport>()), Times.Never);
        }
    }
}
