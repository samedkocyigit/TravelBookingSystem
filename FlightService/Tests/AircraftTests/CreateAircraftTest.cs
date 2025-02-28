using AutoMapper;
using FlightService.Domain.Dtos.Aircraft;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AircraftRepositories;
using FlightService.Services.AircraftServices;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FlightService.Tests.AircraftTests
{
    public class CreateAircraftTest
    {
        protected readonly Mock<IAircraftRepository> _aircraftRepository;
        protected readonly IAircraftService _aircraftService;
        protected readonly Mock<IMapper> _mapper;

        public CreateAircraftTest()
        {
            _aircraftRepository = new Mock<IAircraftRepository>();
            _mapper = new Mock<IMapper>();
            _aircraftService = new AircraftService(_aircraftRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Should_CreateAircraft_When_ValidCreateAircraftDtoIsPassed()
        {
            var createAircraftDto = new CreateAircraftDto
            {
                Model = "Boeing 737",
                Capacity = 200
            };

            var aircraft = new Aircraft
            {
                Id = Guid.NewGuid(),
                Model = "Boeing 737",
                Capacity = 200
            };

            var aircraftResponseDto = new AircraftResponseDto
            {
                Id = aircraft.Id,
                Model = aircraft.Model,
                Capacity = aircraft.Capacity
            };

            _mapper.Setup(m => m.Map<Aircraft>(createAircraftDto)).Returns(aircraft);
            _mapper.Setup(m => m.Map<AircraftResponseDto>(aircraft)).Returns(aircraftResponseDto);

            _aircraftRepository.Setup(x => x.CreateAircraft(It.IsAny<Aircraft>()))
                               .ReturnsAsync(aircraft);

            var result = await _aircraftService.CreateAircraft(createAircraftDto);

            Assert.NotNull(result);
            Assert.Equal(aircraftResponseDto.Id, result.Id);
            Assert.Equal(aircraftResponseDto.Model, result.Model);
            Assert.Equal(aircraftResponseDto.Capacity, result.Capacity);

            _aircraftRepository.Verify(r => r.CreateAircraft(It.IsAny<Aircraft>()), Times.Once);

            _mapper.Verify(m => m.Map<Aircraft>(createAircraftDto), Times.Once);
            _mapper.Verify(m => m.Map<AircraftResponseDto>(aircraft), Times.Once);
        }

        [Fact]
        public async Task Should_ThrowValidationException_When_ModelOrCapacityIsInvalid()
        {
            CreateAircraftDto createAircraftDto = new CreateAircraftDto
            {
                Model = null,  
                Capacity = -1  
            };

            
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _aircraftService.CreateAircraft(createAircraftDto));

            Assert.NotNull(exception);
            Assert.IsType<ValidationException>(exception);
            Assert.Equal("Model and Capacity are required.", exception.Message); 

            _aircraftRepository.Verify(r => r.CreateAircraft(It.IsAny<Aircraft>()), Times.Never);
            _mapper.Verify(m => m.Map<Aircraft>(createAircraftDto), Times.Never);
            _mapper.Verify(m => m.Map<AircraftResponseDto>(It.IsAny<Aircraft>()), Times.Never);
        }

    }
}
