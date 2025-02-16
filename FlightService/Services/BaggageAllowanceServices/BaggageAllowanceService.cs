using AutoMapper;
using FlightService.Domain.Dtos.BaggageAllowance;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.BaggageAllowanceRepositories;

namespace FlightService.Services.BaggageAllowanceServices
{
    public class BaggageAllowanceService : IBaggageAllowanceService
    {
        protected readonly IBaggageAllowanceRepository _baggageAllowanceRepository;
        protected readonly IMapper _mapper;
        public BaggageAllowanceService(IBaggageAllowanceRepository baggageAllowanceRepository,IMapper mapper)
        {
            _baggageAllowanceRepository = baggageAllowanceRepository;
            _mapper = mapper;
        }

        public async Task<List<BaggageAllowanceResponseDto>> GetAllBaggageAllowances()
        {
            var baggageAllowances = await _baggageAllowanceRepository.GetAllBaggageAllowances();
            var mappedBaggageAllowances = _mapper.Map<List<BaggageAllowanceResponseDto>>(baggageAllowances);
            return mappedBaggageAllowances;
        }
        public async Task<BaggageAllowanceResponseDto> GetBaggageAllowanceById(Guid id)
        {
            var baggageAllowance = await _baggageAllowanceRepository.GetBaggageAllowanceById(id);
            var mappedBaggageAllowance = _mapper.Map<BaggageAllowanceResponseDto>(baggageAllowance);
            return mappedBaggageAllowance;
        }
        public async Task<BaggageAllowanceResponseDto> CreateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto)
        {
            var baggageAllowance = _mapper.Map<BaggageAllowance>(baggageAllowanceDto);
            var newBaggageAllowance = await _baggageAllowanceRepository.CreateBaggageAllowance(baggageAllowance);
            var mappedBaggageAllowance = _mapper.Map<BaggageAllowanceResponseDto>(newBaggageAllowance);
            return mappedBaggageAllowance;
        }

        public async Task<BaggageAllowanceResponseDto> UpdateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto)
        {
            var baggageAllowance = _mapper.Map<BaggageAllowance>(baggageAllowanceDto);
            var updatedBaggageAllowance = await _baggageAllowanceRepository.UpdateBaggageAllowance(baggageAllowance);
            var mappedBaggageAllowance = _mapper.Map<BaggageAllowanceResponseDto>(updatedBaggageAllowance);
            return mappedBaggageAllowance;
        }

        public async Task DeleteBaggageAllowance(Guid id)
        {
            await _baggageAllowanceRepository.DeleteBaggageAllowance(id);
        }
    }
}
