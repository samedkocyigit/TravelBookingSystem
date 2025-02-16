using FlightService.Domain.Dtos.Flight;
using FlightService.Domain.Models;
using FlightService.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController:ControllerBase
    {
        protected readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightService.GetAllFlights();
            return Ok(flights);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFlightById(Guid id)
        {
            var flight = await _flightService.GetFlightById(id);
            return Ok(flight);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDto flightDto)
        {
            var newFlight = await _flightService.CreateFlight(flightDto);
            return Ok(newFlight);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFlight(CreateFlightDto flightDto)
        {
            var updatedFlight = await _flightService.UpdateFlight(flightDto);
            return Ok(updatedFlight);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            await _flightService.DeleteFlight(id);
            return Ok();
        }

    }
}
