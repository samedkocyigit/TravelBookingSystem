using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.FloorRepositories;
using HotelService.Infrastructure.Repositories.HotelRepositories;
using HotelService.Infrastructure.Repositories.RoomRepositories;
using HotelService.Models.Enums;
using HotelService.Models.Models;
using HotelService.Services.RoomServices;
using Moq;
using Xunit;

namespace HotelService.Tests.RoomTests
{
    public class CreateRoomTests
    {
        protected readonly Mock<IRoomRepository> _roomRepository;
        protected readonly Mock<IHotelRepository> _hotelRepository;
        protected readonly Mock<IFloorRepository> _floorRepository;
        protected readonly Mock<IMapper> _mapper;
        protected readonly RoomService _roomService;

        public CreateRoomTests()
        {
            _mapper = new Mock<IMapper>();
            _roomRepository = new Mock<IRoomRepository>();
            _hotelRepository = new Mock<IHotelRepository>();
            _floorRepository = new Mock<IFloorRepository>();
            _roomService = new RoomService(_roomRepository.Object, _hotelRepository.Object, _floorRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task ShouldCreateRoom_WhenRoomCreationDto_IsValid()
        {
            var roomDto = new RoomCreationDto
            {
                roomType = RoomType.Single,
                floorId = Guid.NewGuid()
            };

            var mappedRoom = new Room
            {
                Id = Guid.NewGuid(),
                RoomType = roomDto.roomType,
                Floor = new Floor { HotelId = Guid.NewGuid() }
            };

            var floor = new Floor { Id = roomDto.floorId, HotelId = mappedRoom.Floor.HotelId };
            var hotel = new Hotel { Id = floor.HotelId, RoomCapacity = 10, AvailableRoom = 5 };

            _mapper.Setup(m => m.Map<Room>(roomDto)).Returns(mappedRoom);
            _floorRepository.Setup(f => f.GetFloorById(roomDto.floorId)).ReturnsAsync(floor);
            _roomRepository.Setup(r => r.GetLastRoomNumberInHotel(floor.HotelId)).ReturnsAsync(101);
            _roomRepository.Setup(r => r.CreateRoom(It.IsAny<Room>())).ReturnsAsync(mappedRoom);
            _hotelRepository.Setup(h => h.GetHotelById(floor.HotelId)).ReturnsAsync(hotel);
            _roomRepository.Setup(r => r.AvailableRoomNumber(hotel.Id)).ReturnsAsync(4);

            var result = await _roomService.CreateRoom(roomDto);

            Assert.NotNull(result);
            Assert.Equal(roomDto.roomType, result.RoomType);
            Assert.Equal(101, result.RoomNumber);

            _roomRepository.Verify(r => r.CreateRoom(It.Is<Room>(r => r.RoomType == RoomType.Single)), Times.Once);

            _hotelRepository.Verify(h => h.UpdateHotel(It.Is<Hotel>(h => h.RoomCapacity == 11)), Times.Once);
        }

        [Fact]
        public async Task ShouldThrowException_WhenRoomCreationDto_IsInvalid()
        {
            var roomDto = new RoomCreationDto
            {
                floorId = Guid.Empty,
            };

            var expection = await Assert.ThrowsAsync<Exception>(() => _roomService.CreateRoom(roomDto));


            Assert.NotNull(expection);
            Assert.IsType<Exception>(expection);
            Assert.Equal("Invalid input", expection.Message);

            _roomRepository.Verify(r => r.CreateRoom(It.IsAny<Room>()), Times.Never);
            _floorRepository.Verify(f => f.GetFloorById(It.IsAny<Guid>()), Times.Never);
            _roomRepository.Verify(r => r.GetLastRoomNumberInHotel(It.IsAny<Guid>()), Times.Never);
            _hotelRepository.Verify(h => h.GetHotelById(It.IsAny<Guid>()), Times.Never);
            _roomRepository.Verify(r => r.AvailableRoomNumber(It.IsAny<Guid>()), Times.Never);
            _mapper.Verify(m => m.Map<Room>(It.IsAny<RoomCreationDto>()), Times.Never);

        }


    }
}
