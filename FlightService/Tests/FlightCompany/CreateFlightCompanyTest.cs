using AutoMapper;
using FlightService.Domain.Dtos.FlightCompany;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories;
using FlightService.Services.FlightCompanyServices;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FlightService.Tests.FlightCompanyTests
{
    public class CreateFlightCompanyTest
    {
        protected readonly Mock<IFlightCompanyRepository> _flightCompanyRepository;
        protected readonly IFlightCompanyService _flightCompanyService;
        protected readonly Mock<IMapper> _mapper;

        public CreateFlightCompanyTest()
        {
            _flightCompanyRepository = new Mock<IFlightCompanyRepository>();
            _mapper = new Mock<IMapper>();
            _flightCompanyService = new FlightCompanyService(_flightCompanyRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task ShouldCreate_IsFlightCompanyDto_Valid()
        {
            var createFlightCompanyDto = new CreateFlightCompanyDto
            {
                Name = "test",
                Code = "ttt",
            };
            var flightCompany = new FlightCompany
            {
                Id = Guid.NewGuid(),
                Name = createFlightCompanyDto.Name,
                Code = createFlightCompanyDto.Code
            };
            var flightCompanyResponseDto = new FlightCompanyResponseDto
            {
                Id = flightCompany.Id,
                Name = flightCompany.Name,
                Code = flightCompany.Code
            };

            _mapper.Setup(m => m.Map<FlightCompany>(createFlightCompanyDto)).Returns(flightCompany);
            _mapper.Setup(m => m.Map<FlightCompanyResponseDto>(flightCompany)).Returns(flightCompanyResponseDto);
            _flightCompanyRepository.Setup(x => x.CreateFlightCompany(It.IsAny<FlightCompany>()))
                                   .ReturnsAsync(flightCompany);
            var result = await _flightCompanyService.CreateFlightCompany(createFlightCompanyDto);
            Assert.NotNull(result);
            Assert.Equal(flightCompanyResponseDto.Id, result.Id);
            Assert.Equal(flightCompanyResponseDto.Name, result.Name);
            Assert.Equal(flightCompanyResponseDto.Code, result.Code);
        }

        [Fact]
        public async Task ShouldThrowException_IsCreateFlightCompanyDto_Invalid()
        {
            var createFlightCompanyDto = new CreateFlightCompanyDto
            {
                Name = "test",
                Code = "tt",
            };
            var ex = await Assert.ThrowsAsync<ValidationException>(() => _flightCompanyService.CreateFlightCompany(createFlightCompanyDto));

            Assert.NotNull(ex);
            Assert.IsType<ValidationException>(ex);
            Assert.Equal("Name is required and Code must be 2 characters long.", ex.Message);

            _flightCompanyRepository.Verify(r => r.CreateFlightCompany(It.IsAny<FlightCompany>()), Times.Never);    
            _mapper.Verify(m => m.Map<FlightCompany>(createFlightCompanyDto), Times.Never);
            _mapper.Verify(m => m.Map<FlightCompanyResponseDto>(It.IsAny<FlightCompany>()), Times.Never);
        }

    }
}
