using HotelService.Domain.Dtos;
using HotelService.Models.Models;
using HotelService.Services.HotelServices;
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
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            return Ok(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHotel(HotelCreationDto hotelDto)
        {
            var newHotel = await _hotelService.CreateHotel(hotelDto);
            return Ok(newHotel);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHotel(Hotel hotel)
        {
            var updatedHotel = await _hotelService.UpdateHotel(hotel);
            return Ok(updatedHotel);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            await _hotelService.DeleteHotel(id);
            return Ok();
        }
    }
}
