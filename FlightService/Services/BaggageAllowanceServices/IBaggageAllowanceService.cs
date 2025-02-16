using FlightService.Domain.Dtos.BaggageAllowance;
using FlightService.Domain.Models;

namespace FlightService.Services.BaggageAllowanceServices
{
    public interface IBaggageAllowanceService
    {
        Task<List<BaggageAllowanceResponseDto>> GetAllBaggageAllowances();
        Task<BaggageAllowanceResponseDto> GetBaggageAllowanceById(Guid id);
        Task<BaggageAllowanceResponseDto> CreateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto);
        Task<BaggageAllowanceResponseDto> UpdateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto);
        Task DeleteBaggageAllowance(Guid id);
    }
}
