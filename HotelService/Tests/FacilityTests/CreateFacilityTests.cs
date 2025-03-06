using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.FacilityRepositories;
using HotelService.Models.Models;
using HotelService.Services.FacilityServices;
using Moq;
using Xunit;

namespace HotelService.Tests.FacilityTests
{
    public class CreateFacilityTests
    {
        protected readonly Mock<IFacilityRepository> _facilityRepository;
        protected readonly Mock<IMapper> _mapper;
        protected readonly FacilityService _facilityService;

        public CreateFacilityTests()
        {
            _facilityRepository = new Mock<IFacilityRepository>();
            _mapper = new Mock<IMapper>();
            _facilityService = new FacilityService(_facilityRepository.Object, _mapper.Object);

        }

        [Fact]
        public async Task Should_create_facility()
        {
            var facilityDto = new FacilityCreationDto
            {
                floorId = Guid.NewGuid(),
                name = "Test Facility"
            };

            var facility = new Facility
            {
                Id = Guid.NewGuid(),
                FloorId = facilityDto.floorId,
                Name = facilityDto.name
            };

            _mapper.Setup(m => m.Map<Facility>(facilityDto)).Returns(facility);
            _facilityRepository.Setup(x => x.CreateFacility(It.IsAny<Facility>())).ReturnsAsync(facility);

            var result = await _facilityService.CreateFacility(facilityDto);

            Assert.NotNull(result);
            Assert.Equal(facility.Id, result.Id);
            Assert.Equal(facility.FloorId, result.FloorId);
            Assert.Equal(facility.Name, result.Name);

            _facilityRepository.Verify(x => x.CreateFacility(It.IsAny<Facility>()), Times.Once);
            _mapper.Verify(x => x.Map<Facility>(facilityDto), Times.Once);

        }
        [Fact]
        public async Task Should_throw_exception_when_invalid_facility_creation_dto_is_passed()
        {
            var facilityDto = new FacilityCreationDto
            {
                floorId = Guid.NewGuid(),
                name = ""
            };
            var expection = await Assert.ThrowsAsync<Exception>(() => _facilityService.CreateFacility(facilityDto));
            Assert.IsType<Exception>(expection);
            Assert.Equal("Invalid input", expection.Message);
            _facilityRepository.Verify(x => x.CreateFacility(It.IsAny<Facility>()), Times.Never);
        }

    }


}
