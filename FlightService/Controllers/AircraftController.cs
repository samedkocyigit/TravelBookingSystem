using FlightService.Domain.Models;
using FlightService.Services.AircraftServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;
        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAircrafts()
        {
            var aircrafts = await _aircraftService.GetAllAircrafts();
            return Ok(aircrafts);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAircraftById(Guid id)
        {
            var aircraft = await _aircraftService.GetAircraftById(id);
            return Ok(aircraft);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAircraft(Aircraft aircraft)
        {
            var newAircraft = await _aircraftService.CreateAircraft(aircraft);
            return Ok(newAircraft);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAircraft(Aircraft aircraft)
        {
            var updatedAircraft = await _aircraftService.UpdateAircraft(aircraft);
            return Ok(updatedAircraft);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAircraft(Guid id)
        {
            await _aircraftService.DeleteAircraft(id);
            return Ok();
        }

    }
}
