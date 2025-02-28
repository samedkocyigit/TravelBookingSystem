using AutoMapper;
using FlightService.Domain.Dtos.BaggageAllowance;
using FlightService.Domain.Enums;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.BaggageAllowanceRepositories;
using FlightService.Services.BaggageAllowanceServices;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FlightService.Tests.BaggageAllowanceTests
{
    public class CreateBaggageAllowanceTest
    {
        protected readonly Mock<IBaggageAllowanceRepository> _baggageAllowanceRepository;
        protected readonly IBaggageAllowanceService _baggageAllowanceService;
        protected readonly Mock<IMapper> _mapper;

        public CreateBaggageAllowanceTest()
        {
            _baggageAllowanceRepository = new Mock<IBaggageAllowanceRepository>();
            _mapper = new Mock<IMapper>();
            _baggageAllowanceService = new BaggageAllowanceService(_baggageAllowanceRepository.Object, _mapper.Object);
        }
        
        [Fact]
        public async Task ShouldCreate_IsCreateBaggageAllowanceDto_Valid()
        {
            var createBaggageAllowanceDto = new CreateBaggageAllowanceDto
            {
                ExtraChargePerKg = 10,
                SeatClass = SeatClass.Business,
                WeightLimitKg = 20,
                FlightId = Guid.NewGuid()
            };
            var baggageAllowance = new BaggageAllowance
            {
                Id = Guid.NewGuid(),
                SeatClass = createBaggageAllowanceDto.SeatClass,
                WeightLimitKg = createBaggageAllowanceDto.WeightLimitKg,
                ExtraChargePerKg = createBaggageAllowanceDto.ExtraChargePerKg,
                FlightId = createBaggageAllowanceDto.FlightId
            };
            var baggageAllowanceResponseDto = new BaggageAllowanceResponseDto
            {
                Id = baggageAllowance.Id,
                SeatClass = baggageAllowance.SeatClass,
                WeightLimitKg = baggageAllowance.WeightLimitKg,
                ExtraChargePerKg = baggageAllowance.ExtraChargePerKg,
                FlightId = baggageAllowance.FlightId
            };

            _mapper.Setup(m => m.Map<BaggageAllowance>(createBaggageAllowanceDto)).Returns(baggageAllowance);
            _mapper.Setup(m => m.Map<BaggageAllowanceResponseDto>(baggageAllowance)).Returns(baggageAllowanceResponseDto);
            _baggageAllowanceRepository.Setup(x => x.CreateBaggageAllowance(It.IsAny<BaggageAllowance>()))
                                       .ReturnsAsync(baggageAllowance);
            var result = await _baggageAllowanceService.CreateBaggageAllowance(createBaggageAllowanceDto);
            Assert.NotNull(result);
            Assert.Equal(baggageAllowanceResponseDto.Id, result.Id);
            Assert.Equal(baggageAllowanceResponseDto.WeightLimitKg, result.WeightLimitKg);
            Assert.Equal(baggageAllowanceResponseDto.SeatClass.ToString(), result.SeatClass.ToString());
            Assert.Equal(baggageAllowanceResponseDto.ExtraChargePerKg, result.ExtraChargePerKg);
            Assert.Equal(baggageAllowanceResponseDto.FlightId, result.FlightId);
        }
        [Fact]
        public async Task ShouldThrowValidationException_When_CreateBaggageAllowanceDto_IsInvalid()
        {
            var createBaggageAllowanceDto = new CreateBaggageAllowanceDto
            {
                ExtraChargePerKg = -10,
                WeightLimitKg = -2,
                FlightId = new Guid()
            };
            var exeption =await Assert.ThrowsAsync<ValidationException>(() => _baggageAllowanceService.CreateBaggageAllowance(createBaggageAllowanceDto));
            
            Assert.NotNull(exeption);
            Assert.IsType<ValidationException>(exeption);
            Assert.Equal("ExtraChargePerKg, WeightLimitKg and SeatClass are required.", exeption.Message);

            _baggageAllowanceRepository.Verify(r => r.CreateBaggageAllowance(It.IsAny<BaggageAllowance>()), Times.Never);
            _mapper.Verify(m => m.Map<BaggageAllowance>(createBaggageAllowanceDto), Times.Never);
            _mapper.Verify(m => m.Map<BaggageAllowanceResponseDto>(It.IsAny<BaggageAllowance>()), Times.Never);
        }
    }
}
