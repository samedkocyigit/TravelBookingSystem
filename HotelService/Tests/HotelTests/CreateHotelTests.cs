using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.HotelRepositories;
using HotelService.Models.Models;
using HotelService.Services.HotelServices;
using Moq;
using Xunit;

namespace HotelService.Tests.HotelTests
{
    public class CreateHotelTests
    {
        protected readonly Mock<IHotelRepository> _hotelRepository;
        protected readonly Mock<IMapper> _mapper;
        protected readonly HotelsService _hotelService;

        public CreateHotelTests()
        {
            _hotelRepository = new Mock<IHotelRepository>();
            _mapper = new Mock<IMapper>();
            _hotelService = new HotelsService(_hotelRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task CreateHotel_WhenCalled_ReturnsNewHotel()
        {
            // Arrange
            var hotelDto = new HotelCreationDto
            {
                location = "Test Location",
                name = "Test Hotel",
                stars = 5
            };

            var hotel = new Hotel
            {
                Location = hotelDto.location,
                Name = hotelDto.name,
                Stars = hotelDto.stars
            };

            _mapper.Setup(x => x.Map<Hotel>(hotelDto)).Returns(hotel);
            _hotelRepository.Setup(x => x.CreateHotel(hotel)).ReturnsAsync(hotel);

            var res =  await _hotelService.CreateHotel(hotelDto);

            Assert.NotNull(res);
            Assert.Equal(hotelDto.location, res.Location);
            Assert.Equal(hotelDto.name, res.Name);
            Assert.Equal(hotelDto.stars, res.Stars);

            _hotelRepository.Verify(x => x.CreateHotel(hotel), Times.Once);
            _mapper.Verify(x => x.Map<Hotel>(hotelDto), Times.Once);
        }

        [Fact]
        public async Task CreateHotel_WhenCalledWithInvalidInput_ThrowsException()
        {
            // Arrange
            var hotelDto = new HotelCreationDto
            {
                location = "Test Location",
                name = "",
                stars = 0
            };
            
            var expection = await Assert.ThrowsAsync<Exception>(() => _hotelService.CreateHotel(hotelDto));

            Assert.IsType<Exception>(expection);
            Assert.Equal("Invalid input", expection.Message);

            _hotelRepository.Verify(x => x.CreateHotel(It.IsAny<Hotel>()), Times.Never);
            _mapper.Verify(x => x.Map<Hotel>(It.IsAny<HotelCreationDto>()), Times.Never);
        }
    }
}
