using FlightService.Domain.Dtos.BaggageAllowance;
using FlightService.Domain.Models;
using FlightService.Services.BaggageAllowanceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaggageAllowanceController : ControllerBase
    {
        private readonly IBaggageAllowanceService _baggageAllowanceService;
        public BaggageAllowanceController(IBaggageAllowanceService baggageAllowanceService)
        {
            _baggageAllowanceService = baggageAllowanceService;
        }

        // get all baggage allowances
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllBaggageAllowances()
        {
            var baggageAllowances = await _baggageAllowanceService.GetAllBaggageAllowances();
            return Ok(baggageAllowances);
        }

        // get baggage allowance by id
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBaggageAllowanceById(Guid id)
        {
            var baggageAllowance = await _baggageAllowanceService.GetBaggageAllowanceById(id);
            return Ok(baggageAllowance);
        }

        // create baggage allowance
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto)
        {
            var newBaggageAllowance = await _baggageAllowanceService.CreateBaggageAllowance(baggageAllowanceDto);
            return Ok(newBaggageAllowance);
        }

        // update baggage allowance
        [Authorize(Roles= "Admin,Manager")] 
        [HttpPut]
        public async Task<IActionResult> UpdateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto)
        {
            var updatedBaggageAllowance = await _baggageAllowanceService.UpdateBaggageAllowance(baggageAllowanceDto);
            return Ok(updatedBaggageAllowance);
        }

        // delete baggage allowance
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBaggageAllowance(Guid id)
        {
            await _baggageAllowanceService.DeleteBaggageAllowance(id);
            return Ok();
        }
    }
}
