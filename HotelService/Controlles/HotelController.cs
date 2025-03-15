using HotelService.Domain.Dtos;
using HotelService.Models.Models;
using HotelService.Services.HotelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController:ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // get all hotels
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);
        }

        // get hotel by id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            return Ok(hotel);
        }

        // create hotel
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateHotel(HotelCreationDto hotelDto)
        {
            var newHotel = await _hotelService.CreateHotel(hotelDto);
            return Ok(newHotel);
        }

        // update hotel
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateHotel(Hotel hotel)
        {
            var updatedHotel = await _hotelService.UpdateHotel(hotel);
            return Ok(updatedHotel);
        }

        // delete hotel with id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            await _hotelService.DeleteHotel(id);
            return Ok();
        }

        // get all available rooms
        [HttpGet]
        [Route("available-rooms")]
        public async Task<IActionResult> GetAllAvailableRooms()
        {
            var availableRooms = await _hotelService.GetAllAvailableRooms();
            return Ok(availableRooms);
        }

        // add manager to hotel
        [HttpPut]
        [Route("new-manager/{id}")]
        public async Task<IActionResult> AddManager(Guid id)
        {
            await _hotelService.AddManager(id);
            return Ok();
        }
    }
}
