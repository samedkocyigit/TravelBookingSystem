using HotelService.Models.Models;
using HotelService.Services.FloorServices;
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
        [HttpGet]
        public async Task<IActionResult> GetAllFloors()
        {
            var floors = await _floorService.GetAllFloors();
            return Ok(floors);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFloorById(Guid id)
        {
            var floor = await _floorService.GetFloorById(id);
            return Ok(floor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFloor(Floor floor)
        {
            var newFloor = await _floorService.CreateFloor(floor);
            return Ok(newFloor);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFloor(Floor floor)
        {
            var updatedFloor = await _floorService.UpdateFloor(floor);
            return Ok(updatedFloor);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFloor(Guid id)
        {
            await _floorService.DeleteFloor(id);
            return Ok();
        }
    }
}
