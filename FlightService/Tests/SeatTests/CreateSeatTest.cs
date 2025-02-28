using AutoMapper;
using FlightService.Domain.Dtos.Seat;
using FlightService.Domain.Enums;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.SeatRepositories;
using FlightService.Services.SeatServices;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FlightService.Tests.SeatTests
{
    public class CreateSeatTest
    {
        protected readonly Mock<ISeatRepository> _seatRepository;
        protected readonly ISeatService _seatService;
        protected readonly Mock<IMapper> _mapper;

        public CreateSeatTest()
        {
            _seatRepository = new Mock<ISeatRepository>();
            _mapper = new Mock<IMapper>();
            _seatService = new SeatService(_seatRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task ShouldCreate_IsCreateSeatDto_Valid()
        {
            var createSeatDto = new CreateSeatDto
            {

                SeatNumber = "1A",
                SeatClass = SeatClass.Business,
                FlightId = Guid.NewGuid(),
                TicketPriceId = Guid.NewGuid()
            };
            var seat = new Seat
            {
                Id = Guid.NewGuid(),
                SeatNumber = createSeatDto.SeatNumber,
                SeatClass = createSeatDto.SeatClass,
                FlightId = createSeatDto.FlightId,
                TicketPriceId = createSeatDto.TicketPriceId
            };
            var seatResponseDto = new SeatResponseDto
            {
                Id = seat.Id,
                SeatNumber = seat.SeatNumber,
                SeatClass = seat.SeatClass,
                FlightId = seat.FlightId,
                TicketPriceId = seat.TicketPriceId
            };

            _mapper.Setup(m => m.Map<Seat>(createSeatDto)).Returns(seat);
            _mapper.Setup(m => m.Map<SeatResponseDto>(seat)).Returns(seatResponseDto);

            _seatRepository.Setup(x => x.CreateSeat(It.IsAny<Seat>()))
                                   .ReturnsAsync(seat);

            var result = await _seatService.CreateSeat(createSeatDto);
            Assert.NotNull(result);
            Assert.Equal(seatResponseDto.Id, result.Id);
            Assert.Equal(seatResponseDto.SeatNumber, result.SeatNumber);
            Assert.Equal(seatResponseDto.SeatClass, result.SeatClass);
            Assert.Equal(seatResponseDto.FlightId, result.FlightId);
            Assert.Equal(seatResponseDto.TicketPriceId, result.TicketPriceId);

            _seatRepository.Verify(x => x.CreateSeat(It.IsAny<Seat>()), Times.Once);
            _mapper.Verify(m => m.Map<Seat>(createSeatDto), Times.Once);
            _mapper.Verify(m => m.Map<SeatResponseDto>(seat), Times.Once);

        }

        [Fact]
        public async Task ShouldThrowException_IsCreateSeatDto_Invalid()
        {
            var seatDto = new CreateSeatDto
            {
                SeatNumber = "1A",
                FlightId = Guid.Empty,
                TicketPriceId = Guid.Empty
            };

            var ex =await Assert.ThrowsAsync<ValidationException>(() => _seatService.CreateSeat(seatDto));

            Assert.NotNull(ex);
            Assert.IsType<ValidationException>(ex);
            Assert.Equal("SeatClass, SeatNumber, FlightId and TicketPriceId are required.", ex.Message);

        }
    }
	
}
