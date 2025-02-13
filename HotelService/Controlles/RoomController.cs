using HotelService.Domain.Dtos;
using HotelService.Models.Models;
using HotelService.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var room = await _roomService.GetRoomById(id);
            return Ok(room);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomCreationDto roomDto)
        {
            var newRoom = await _roomService.CreateRoom(roomDto);
            return Ok(newRoom);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room room)
        {
            var updatedRoom = await _roomService.UpdateRoom(room);
            return Ok(updatedRoom);
        } 
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            await _roomService.DeleteRoom(id);
            return Ok();
        }
    }
}
