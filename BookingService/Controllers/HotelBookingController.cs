using BookingService.Domain.Models;
using BookingService.Services.HotelBookingServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingServices _hotelBookingService;
        public HotelBookingController(IHotelBookingServices hotelBookingService)
        {
            _hotelBookingService = hotelBookingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotelBookings()
        {
            var bookings = await _hotelBookingService.GetAllBookings();
            return Ok(bookings);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHotelBookingById(Guid id)
        {
            var booking = await _hotelBookingService.GetBookingById(id);
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHotelBooking(HotelBooking booking)
        {
            var newBooking = await _hotelBookingService.CreateBooking(booking);
            return Ok(newBooking);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHotelBooking(HotelBooking booking)
        {
            var updatedBooking = await _hotelBookingService.UpdateBooking(booking);
            return Ok(updatedBooking);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _hotelBookingService.DeleteBooking(id);
            return Ok();
        }
    }
}
