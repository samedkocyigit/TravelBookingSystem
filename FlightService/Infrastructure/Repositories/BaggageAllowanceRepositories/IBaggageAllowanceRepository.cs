using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.BaggageAllowanceRepositories
{
    public interface IBaggageAllowanceRepository
    {
        Task<List<BaggageAllowance>> GetAllBaggageAllowances();
        Task<BaggageAllowance> GetBaggageAllowanceById(Guid id);
        Task<BaggageAllowance> CreateBaggageAllowance(BaggageAllowance baggageAllowance);
        Task<BaggageAllowance> UpdateBaggageAllowance(BaggageAllowance baggageAllowance);
        Task DeleteBaggageAllowance(Guid id);
    }
}
