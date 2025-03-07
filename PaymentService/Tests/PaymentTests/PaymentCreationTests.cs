using AutoMapper;
using Moq;
using Moq.Protected;
using PaymentService.Domain.Dtos;
using PaymentService.Domain.Models;
using PaymentService.Infrastructure.Repositories.PaymentRepositories;
using PaymentService.Services.PaymentServices;
using System.Net;
using Xunit;

namespace PaymentService.Tests.PaymentTests
{
    public class PaymentCreationTests
    {   
        protected readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        protected readonly Mock<IHttpClientFactory> _httpClientFactory;
        protected readonly Mock<IMapper> _mapperMock;
        protected readonly IPaymentServices _paymentService;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public PaymentCreationTests()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                              .Returns(httpClient);

            _mapperMock = new Mock<IMapper>();
            _paymentService = new PaymentsService(_paymentRepositoryMock.Object, _httpClientFactory.Object, _mapperMock.Object);
        }
        [Fact]
        public async Task ShouldCreatePayment_WhenCreationDto_IsValid()
        {
            var userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Doe",
                Payments = new List<PaymentDto>
                {
                    new PaymentDto
                    {
                        CardHolderName = "John Doe",
                        CVV = "123",
                        CardNumber = "1234567890123456",
                        ExpiryDate = "12/25",
                        PaymentLimit = 1000
                    }
                }
            };

            var bookingDto = new BookingDto
            {
                Id = Guid.NewGuid(),
                TotalAmount = 100
            };
            var paymentCreationDto = new PaymentCreationDto
            {
                UserToBeCharged = userDto.Id,
                BookingId = bookingDto.Id,
                CardHolderName = "John Doe",
                CVV = "123",
                CardNumber = "1234567890123456",
                ExpiryDate = "12/25"
            };


            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                UserToBeCharged = paymentCreationDto.UserToBeCharged,
                BookingId = paymentCreationDto.BookingId,
                CardHolderName = paymentCreationDto.CardHolderName,
                CVV = paymentCreationDto.CVV,
                CardNumber = paymentCreationDto.CardNumber,
                ExpiryDate = paymentCreationDto.ExpiryDate
            };

            _mockHttpMessageHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                        ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.ToString().Contains("/api/User")),
                        ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage
                        {
                        StatusCode = HttpStatusCode.OK,
                        Content = JsonContent.Create(userDto)
                        });

            _mockHttpMessageHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                            ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.ToString().Contains("/api/HotelBooking")),
                            ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = JsonContent.Create(bookingDto)
                        });

            _mapperMock.Setup(x => x.Map<Payment>(It.IsAny<PaymentCreationDto>()))
                       .Returns(payment);
            
            _httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                              .Returns(new HttpClient(_mockHttpMessageHandler.Object));

            _paymentRepositoryMock.Setup(x => x.CreatePayment(It.IsAny<Payment>()))
                                  .ReturnsAsync(payment);

            var result = await _paymentService.CreatePayment(paymentCreationDto);

            Assert.NotNull(result);
            Assert.Equal(payment.UserToBeCharged, result.UserToBeCharged);
            Assert.Equal(payment.BookingId, result.BookingId);
            Assert.Equal(payment.CardHolderName, result.CardHolderName);
            Assert.Equal(payment.CVV, result.CVV);
            Assert.Equal(payment.CardNumber, result.CardNumber);
            Assert.Equal(payment.ExpiryDate, result.ExpiryDate);

            _paymentRepositoryMock.Verify(x => x.CreatePayment(It.IsAny<Payment>()), Times.Once);
            _httpClientFactory.Verify(x => x.CreateClient(It.IsAny<string>()), Times.Once);
            _mapperMock.Verify(x => x.Map<Payment>(It.IsAny<PaymentCreationDto>()), Times.Once);
        }
    }
}
