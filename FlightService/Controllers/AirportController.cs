using FlightService.Domain.Dtos.Airport;
using FlightService.Domain.Models;
using FlightService.Services.AirportServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAirports()
        {
            var airports = await _airportService.GetAllAirports();
            return Ok(airports);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAirportById(Guid id)
        {
            var airport = await _airportService.GetAirportById(id);
            return Ok(airport);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAirport(CreateAirportDto airportDto)
        {
            var newAirport = await _airportService.CreateAirport(airportDto);
            return Ok(newAirport);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAirport(CreateAirportDto airportDto)
        {
            var updatedAirport = await _airportService.UpdateAirport(airportDto);
            return Ok(updatedAirport);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAirport(Guid id)
        {
            await _airportService.DeleteAirport(id);
            return Ok();
        }

    }
}
