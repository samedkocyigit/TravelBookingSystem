using FlightService.Domain.Models;

namespace FlightService.Services.BaggageAllowanceServices
{
    public interface IBaggageAllowanceService
    {
        Task<List<BaggageAllowance>> GetAllBaggageAllowances();
        Task<BaggageAllowance> GetBaggageAllowanceById(Guid id);
        Task<BaggageAllowance> CreateBaggageAllowance(BaggageAllowance baggageAllowance);
        Task<BaggageAllowance> UpdateBaggageAllowance(BaggageAllowance baggageAllowance);
        Task DeleteBaggageAllowance(Guid id);
    }
}
