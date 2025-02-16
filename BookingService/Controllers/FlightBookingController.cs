using BookingService.Domain.Models;
using BookingService.Services.FlightBookingServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightBookingController : ControllerBase
    {
        private readonly IFlightBookingServices _flightBookingService;
        public FlightBookingController(IFlightBookingServices flightBookingService)
        {
            _flightBookingService = flightBookingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _flightBookingService.GetAllBookings();
            return Ok(bookings);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var booking = await _flightBookingService.GetBookingById(id);
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(FlightBooking booking)
        {
            var newBooking = await _flightBookingService.CreateBooking(booking);
            return Ok(newBooking);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(FlightBooking booking)
        {
            var updatedBooking = await _flightBookingService.UpdateBooking(booking);
            return Ok(updatedBooking);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _flightBookingService.DeleteBooking(id);
            return Ok();
        }
    }
}
