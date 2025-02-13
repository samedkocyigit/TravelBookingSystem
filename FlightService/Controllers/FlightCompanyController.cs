using FlightService.Domain.Models;
using FlightService.Services.FlightCompanyServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightCompanyController : ControllerBase
    {
        private readonly IFlightCompanyService _flightCompanyService;
        public FlightCompanyController(IFlightCompanyService flightCompanyService)
        {
            _flightCompanyService = flightCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFlightCompanys()
        {
            var flightCompanys = await _flightCompanyService.GetAllFlightCompanies();
            return Ok(flightCompanys);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFlightCompanyById(Guid id)
        {
            var flightCompany = await _flightCompanyService.GetFlightCompanyById(id);
            return Ok(flightCompany);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlightCompany(FlightCompany flightCompany)
        {
            var newFlightCompany = await _flightCompanyService.CreateFlightCompany(flightCompany);
            return Ok(newFlightCompany);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFlightCompany(FlightCompany flightCompany)
        {
            var updatedFlightCompany = await _flightCompanyService.UpdateFlightCompany(flightCompany);
            return Ok(updatedFlightCompany);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlightCompany(Guid id)
        {
            await _flightCompanyService.DeleteFlightCompany(id);
            return Ok();
        }

    }
}
