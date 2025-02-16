using AutoMapper;
using FlightService.Domain.Dtos.Seat;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.SeatRepositories;

namespace FlightService.Services.SeatServices
{
    public class SeatService : ISeatService
    {
        protected readonly ISeatRepository _seatRepository;
        protected readonly IMapper _mapper;
        public SeatService(ISeatRepository seatRepository , IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<List<SeatResponseDto>> GetAllSeats()
        {
            var seats = await _seatRepository.GetAllSeats();
            var mappedSeats = _mapper.Map<List<SeatResponseDto>>(seats);    
            return mappedSeats;
        }
        public async Task<SeatResponseDto> GetSeatById(Guid id)
        {
            var seat = await _seatRepository.GetSeatById(id);
            var mappedSeat = _mapper.Map<SeatResponseDto>(seat);
            return mappedSeat;
        }
        public async Task<SeatResponseDto> CreateSeat(CreateSeatDto seatDto)
        {
            var seat = _mapper.Map<Seat>(seatDto);
            var newSeat = await _seatRepository.CreateSeat(seat);
            var mappedSeat = _mapper.Map<SeatResponseDto>(newSeat);
            return mappedSeat;
        }

        public async Task<SeatResponseDto> UpdateSeat(CreateSeatDto seatDto)
        {
            var seat = _mapper.Map<Seat>(seatDto);
            var updatedSeat = await _seatRepository.UpdateSeat(seat);
            var mappedSeat = _mapper.Map<SeatResponseDto>(updatedSeat);
            return mappedSeat;
        }

        public async Task DeleteSeat(Guid id)
        {
            await _seatRepository.DeleteSeat(id);
        }
    }
}
