using BookingService.Domain.Models;
using BookingService.Services.BookingServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices _bookingService;
        public BookingController(IBookingServices bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var booking = await _bookingService.GetBookingById(id);
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            var newBooking = await _bookingService.CreateBooking(booking);
            return Ok(newBooking);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(Booking booking)
        {
            var updatedBooking = await _bookingService.UpdateBooking(booking);
            return Ok(updatedBooking);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _bookingService.DeleteBooking(id);
            return Ok();
        }
    }
}
