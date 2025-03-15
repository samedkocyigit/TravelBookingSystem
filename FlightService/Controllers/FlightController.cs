using FlightService.Domain.Dtos.Flight;
using FlightService.Domain.Models;
using FlightService.Services.FlightServices;
using Microsoft.AspNetCore.Authorization;
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

        // get all flights
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightService.GetAllFlights();
            return Ok(flights);
        }

        // get flight by id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFlightById(Guid id)
        {
            var flight = await _flightService.GetFlightById(id);
            return Ok(flight);
        }

        // create flight
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDto flightDto)
        {
            var newFlight = await _flightService.CreateFlight(flightDto);
            return Ok(newFlight);
        }

        // update flight
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateFlight(CreateFlightDto flightDto)
        {
            var updatedFlight = await _flightService.UpdateFlight(flightDto);
            return Ok(updatedFlight);
        }

        // delete flight
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            await _flightService.DeleteFlight(id);
            return Ok();
        }
    }
}
