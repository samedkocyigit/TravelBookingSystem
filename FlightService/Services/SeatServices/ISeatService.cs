using FlightService.Domain.Models;

namespace FlightService.Services.SeatServices
{
    public interface ISeatService
    {
        Task<List<Seat>> GetAllSeats();
        Task<Seat> GetSeatById(Guid id);
        Task<Seat> CreateSeat(Seat seat);
        Task<Seat> UpdateSeat(Seat seat);
        Task DeleteSeat(Guid id);
    }
}
