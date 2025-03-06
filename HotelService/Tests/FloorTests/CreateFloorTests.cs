using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.FloorRepositories;
using HotelService.Models.Models;
using HotelService.Services.FloorServices;
using Moq;
using Xunit;

namespace HotelService.Tests.FloorTests
{
    public class CreateFloorTests
    {
        protected readonly Mock<IFloorRepository> _floorRepository;
        protected readonly Mock<IMapper> _mapper;
        protected readonly FloorService _floorService;

        public CreateFloorTests()
        {
            _floorRepository = new Mock<IFloorRepository>();
            _mapper = new Mock<IMapper>();
            _floorService = new FloorService(_floorRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task ShouldCreateFloor_WhenValidFloorCreationDtoIsPassed()
        {
            // Arrange
            var floorCreationDto = new FloorCreationDto
            {
                hotelId = Guid.NewGuid(),
                name = "Test Floor",
            };
            var floor = new Floor
            {
                Id = Guid.NewGuid(),
                HotelId = floorCreationDto.hotelId,
                Name = floorCreationDto.name
            };

            _mapper.Setup(m => m.Map<Floor>(floorCreationDto)).Returns(floor);
            _floorRepository.Setup(x => x.CreateFloor(It.IsAny<Floor>()))
                           .ReturnsAsync(floor);
            // Act
            var result = await _floorService.CreateFloor(floorCreationDto);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(floor.Id, result.Id);
            Assert.Equal(floor.HotelId, result.HotelId);
            Assert.Equal(floor.Name, result.Name);

            _floorRepository.Verify(x => x.CreateFloor(It.IsAny<Floor>()), Times.Once);
            _mapper.Verify(x => x.Map<Floor>(floorCreationDto), Times.Once);
        }

        [Fact]
        public async Task ShouldThrowException_WhenInvalidFloorCreationDtoIsPassed()
        {
            // Arrange
            var floorCreationDto = new FloorCreationDto
            {
                hotelId = Guid.NewGuid(),
                name = "",
            };
            var exception = await Assert.ThrowsAsync<Exception>(() => _floorService.CreateFloor(floorCreationDto));
         
            Assert.IsType<Exception>(exception);
            Assert.Equal("Invalid input", exception.Message);
            _floorRepository.Verify(x => x.CreateFloor(It.IsAny<Floor>()), Times.Never);
        }
    }
}
