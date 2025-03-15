using HotelService.Domain.Dtos;
using HotelService.Models.Models;
using HotelService.Services.RoomServices;
using Microsoft.AspNetCore.Authorization;
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

        //get all rooms
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        //get room by id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var room = await _roomService.GetRoomById(id);
            return Ok(room);
        }

        //create room
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomCreationDto roomDto)
        {
            var newRoom = await _roomService.CreateRoom(roomDto);
            return Ok(newRoom);
        }

        //update room
        [Authorize(Roles= "Admin,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room room)
        {
            var updatedRoom = await _roomService.UpdateRoom(room);
            return Ok(updatedRoom);
        }

        //delete room with id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            await _roomService.DeleteRoom(id);
            return Ok();
        }

        //book room
        [Authorize(Roles = "Admin,Manager,User")]
        [HttpPut]
        [Route("book/{roomId}/{userId}")]
        public async Task<IActionResult> BookRoom(Guid roomId, Guid userId)
        {
            var room = await _roomService.BookRoom(roomId, userId);
            return Ok(room);
        }

        //unbook room
        [Authorize(Roles = "Admin,Manager,User")]
        [HttpPut]
        [Route("unbook/{roomId}")]
        public async Task<IActionResult> UnBookRoom(Guid roomId)
        {
            var room = await _roomService.UnBookRoom(roomId);
            return Ok(room);
        }
    }
}
