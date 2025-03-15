using HotelService.Domain.Dtos;
using HotelService.Models.Models;
using HotelService.Services.FloorServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        // get all floors
        [HttpGet]
        public async Task<IActionResult> GetAllFloors()
        {
            var floors = await _floorService.GetAllFloors();
            return Ok(floors);
        }

        // get floor by id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFloorById(Guid id)
        {
            var floor = await _floorService.GetFloorById(id);
            return Ok(floor);
        }

        // create floor
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateFloor(FloorCreationDto floorDto)
        {
            var newFloor = await _floorService.CreateFloor(floorDto);
            return Ok(newFloor);
        }

        // update floor
        [Authorize(Roles= "Admin,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateFloor(Floor floor)
        {
            var updatedFloor = await _floorService.UpdateFloor(floor);
            return Ok(updatedFloor);
        }

        // delete floor with id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFloor(Guid id)
        {
            await _floorService.DeleteFloor(id);
            return Ok();
        }
    }
}
