using BookingService.Domain.Models;
using BookingService.Services.HotelBookingServices;
using BookingService.Services.RoomService;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelBookingController : ControllerBase
    {
        protected readonly IHotelBookingServices _hotelBookingService;
        protected readonly IRoomService _roomService;

        public HotelBookingController(IHotelBookingServices hotelBookingService, IRoomService roomService)
        {
            _hotelBookingService = hotelBookingService;
            _roomService = roomService;
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
        [HttpGet]
        [Route("chech-available-rooms")]
        public async Task<IActionResult> GetAllAvailableRooms()
        {
            var rooms = await _roomService.GetAvailableRoomsFromHotelService();
            return Ok(rooms);
        }
    }
}
