using AutoMapper;
using FlightService.Domain.Dtos.TicketPrice;
using FlightService.Domain.Enums;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.TicketPriceRepositories;
using FlightService.Services.TicketPriceServices;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FlightService.Tests.TicketPriceTests
{
    public class CreateTicketPriceTest
    {
        protected readonly Mock<ITicketPriceRepository> _ticketPriceRepository;
        protected readonly ITicketPriceService _ticketPriceService;
        protected readonly Mock<IMapper> _mapper;
        public CreateTicketPriceTest()
        {
            _ticketPriceRepository = new Mock<ITicketPriceRepository>();
            _mapper = new Mock<IMapper>();
            _ticketPriceService = new TicketPriceService(_ticketPriceRepository.Object, _mapper.Object);
        }
        [Fact]
        public async Task ShouldCreate_IsCreateTicketPriceDto_Valid()
        {
            var createTicketPriceDto = new CreateTicketPriceDto
            {
                Price = 100,
                SeatClass= SeatClass.Business,
                FlightId = Guid.NewGuid()
            };

            var ticketPrice = new TicketPrice
            {
                Id = Guid.NewGuid(),
                Price = createTicketPriceDto.Price,
                SeatClass = createTicketPriceDto.SeatClass,
                FlightId = createTicketPriceDto.FlightId
            };

            var ticketPriceResponseDto = new TicketPriceResponseDto
            {
                Id = ticketPrice.Id,
                SeatClass = ticketPrice.SeatClass,
                Price = ticketPrice.Price,
                FlightId = ticketPrice.FlightId
            };

            _mapper.Setup(m => m.Map<TicketPrice>(createTicketPriceDto)).Returns(ticketPrice);
            _mapper.Setup(m => m.Map<TicketPriceResponseDto>(ticketPrice)).Returns(ticketPriceResponseDto);
            
            _ticketPriceRepository.Setup(x => x.CreateTicketPrice(It.IsAny<TicketPrice>()))
                                   .ReturnsAsync(ticketPrice);
            
            var result = await _ticketPriceService.CreateTicketPrice(createTicketPriceDto);
            
            
            Assert.NotNull(result);
            Assert.Equal(ticketPriceResponseDto.Id, result.Id);
            Assert.Equal(ticketPriceResponseDto.Price, result.Price);
            Assert.Equal(ticketPriceResponseDto.SeatClass, result.SeatClass);
            Assert.Equal(ticketPriceResponseDto.FlightId, result.FlightId);

            _ticketPriceRepository.Verify(m => m.CreateTicketPrice(It.IsAny<TicketPrice>()), Times.Once);
            _mapper.Verify(m => m.Map<TicketPrice>(createTicketPriceDto), Times.Once);
            _mapper.Verify(m => m.Map<TicketPrice>(createTicketPriceDto), Times.Once);
        }

        [Fact]
        public async Task ShouldThrowException_CreateDto_Is_Invalid()
        {
            var createTicketPriceDto = new CreateTicketPriceDto
            {
                Price = -100,
                SeatClass = SeatClass.Business,
                FlightId = Guid.Empty
            };

            var ex = await Assert.ThrowsAsync<ValidationException>(() => _ticketPriceService.CreateTicketPrice(createTicketPriceDto));

            Assert.NotNull(ex);
            Assert.IsType<ValidationException>(ex);
            Assert.Equal("Price, SeatClass and FlightId are required.", ex.Message);
        }
    }
}
