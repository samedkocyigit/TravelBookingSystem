using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.SeatRepositories
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAllSeats();
        Task<Seat> GetSeatById(Guid id);
        Task<Seat> CreateSeat(Seat seat);
        Task<Seat> UpdateSeat(Seat seat);
        Task DeleteSeat(Guid id);
    }
}
