using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.BaggageAllowanceRepositories;

namespace FlightService.Services.BaggageAllowanceServices
{
    public class BaggageAllowanceService : IBaggageAllowanceService
    {
        protected readonly IBaggageAllowanceRepository _baggageAllowanceRepository;
        public BaggageAllowanceService(IBaggageAllowanceRepository baggageAllowanceRepository)
        {
            _baggageAllowanceRepository = baggageAllowanceRepository;
        }

        public async Task<List<BaggageAllowance>> GetAllBaggageAllowances()
        {
            var baggageAllowances = await _baggageAllowanceRepository.GetAllBaggageAllowances();
            return baggageAllowances;
        }
        public async Task<BaggageAllowance> GetBaggageAllowanceById(Guid id)
        {
            var baggageAllowance = await _baggageAllowanceRepository.GetBaggageAllowanceById(id);
            return baggageAllowance;
        }
        public async Task<BaggageAllowance> CreateBaggageAllowance(BaggageAllowance baggageAllowance)
        {
            var newBaggageAllowance = await _baggageAllowanceRepository.CreateBaggageAllowance(baggageAllowance);
            return newBaggageAllowance;
        }

        public async Task<BaggageAllowance> UpdateBaggageAllowance(BaggageAllowance baggageAllowance)
        {
            var updatedBaggageAllowance = await _baggageAllowanceRepository.UpdateBaggageAllowance(baggageAllowance);
            return updatedBaggageAllowance;
        }

        public async Task DeleteBaggageAllowance(Guid id)
        {
            await _baggageAllowanceRepository.DeleteBaggageAllowance(id);
        }
    }
}
