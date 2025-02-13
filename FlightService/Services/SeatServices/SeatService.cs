using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.SeatRepositories;

namespace FlightService.Services.SeatServices
{
    public class SeatService : ISeatService
    {
        protected readonly ISeatRepository _seatRepository;
        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> GetAllSeats()
        {
            var seats = await _seatRepository.GetAllSeats();
            return seats;
        }
        public async Task<Seat> GetSeatById(Guid id)
        {
            var seat = await _seatRepository.GetSeatById(id);
            return seat;
        }
        public async Task<Seat> CreateSeat(Seat seat)
        {
            var newSeat = await _seatRepository.CreateSeat(seat);
            return newSeat;
        }

        public async Task<Seat> UpdateSeat(Seat seat)
        {
            var updatedSeat = await _seatRepository.UpdateSeat(seat);
            return updatedSeat;
        }

        public async Task DeleteSeat(Guid id)
        {
            await _seatRepository.DeleteSeat(id);
        }
    }
}
