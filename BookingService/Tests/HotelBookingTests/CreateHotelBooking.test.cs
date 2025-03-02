using AutoMapper;
using BookingService.Domain.Dtos;
using BookingService.Domain.Models;
using BookingService.Infrastructure.Repositories.HotelBookingRepositories;
using BookingService.Services.HotelBookingServices;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit;

namespace BookingService.Tests.HotelBookingTests
{
    public class CreateHotelBooking
    {
        protected readonly Mock<IHotelBookingRepository> _hotelBookingRepository;
        protected readonly Mock<IHttpClientFactory> _httpClientFactory;
        protected readonly HotelBookingsService _hotelBookingService;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public CreateHotelBooking()
        {
            _hotelBookingRepository = new Mock<IHotelBookingRepository>();
            
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            _httpClientFactory = new Mock<IHttpClientFactory>();
            _httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                              .Returns(httpClient);

            _hotelBookingService = new HotelBookingsService(_hotelBookingRepository.Object, _httpClientFactory.Object);
        }

        [Fact]
        public async Task Should_CreateHotelBooking_When_HotelServiceResponseIsSuccessful()
        {
            // Arrange
            var booking = new HotelBooking
            {
                HotelId = Guid.NewGuid(),
                RoomId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                BookingDateDay = 2,
            };

            var roomDto = new RoomDto
            {
                Id = booking.RoomId,
                PricePerNight = 100
            };

            var newBooking = new HotelBooking
            {
                Id = Guid.NewGuid(),
                HotelId = booking.HotelId,
                RoomId = booking.RoomId,
                UserId = booking.UserId,
                BookingDateDay = booking.BookingDateDay,
                TotalAmount = booking.BookingDateDay * roomDto.PricePerNight
            };

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(roomDto)
                });

            _httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                              .Returns(new HttpClient(_mockHttpMessageHandler.Object));

            _hotelBookingRepository.Setup(x => x.CreateBooking(booking))
                                   .ReturnsAsync(newBooking);

            var result = await _hotelBookingService.CreateBooking(booking);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBooking.Id, result.Id);
            Assert.Equal(newBooking.HotelId, result.HotelId);
            Assert.Equal(newBooking.RoomId, result.RoomId);
            Assert.Equal(newBooking.UserId, result.UserId);
            Assert.Equal(newBooking.BookingDateDay, result.BookingDateDay);
            Assert.Equal(newBooking.TotalAmount, result.TotalAmount);

            _hotelBookingRepository.Verify(x => x.CreateBooking(booking), Times.Once);
        }
    }
}
