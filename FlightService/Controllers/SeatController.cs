using Microsoft.AspNetCore.Mvc;
using FlightService.Domain.Models;
using FlightService.Services.SeatServices;
using FlightService.Domain.Dtos.Seat;

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
        public async Task<IActionResult> CreateSeat(CreateSeatDto seatDto)
        {
            var newSeat = await _seatService.CreateSeat(seatDto);
            return Ok(newSeat);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeat(CreateSeatDto seatDto)
        {
            var updatedSeat = await _seatService.UpdateSeat(seatDto);
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
