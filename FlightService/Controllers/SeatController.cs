using Microsoft.AspNetCore.Mvc;
using FlightService.Domain.Models;
using FlightService.Services.SeatServices;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSeats()
        {
            var seats = await _seatService.GetAllSeats();
            return Ok(seats);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSeatById(Guid id)
        {
            var seat = await _seatService.GetSeatById(id);
            return Ok(seat);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeat(Seat seat)
        {
            var newSeat = await _seatService.CreateSeat(seat);
            return Ok(newSeat);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeat(Seat seat)
        {
            var updatedSeat = await _seatService.UpdateSeat(seat);
            return Ok(updatedSeat);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSeat(Guid id)
        {
            await _seatService.DeleteSeat(id);
            return Ok();
        }

    }
}
