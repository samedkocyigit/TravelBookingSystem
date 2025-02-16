using FlightService.Domain.Dtos.Seat;
using FlightService.Domain.Models;

namespace FlightService.Services.SeatServices
{
    public interface ISeatService
    {
        Task<List<SeatResponseDto>> GetAllSeats();
        Task<SeatResponseDto> GetSeatById(Guid id);
        Task<SeatResponseDto> CreateSeat(CreateSeatDto seatDto);
        Task<SeatResponseDto> UpdateSeat(CreateSeatDto seatDto);
        Task DeleteSeat(Guid id);
    }
}
