﻿using FlightService.Domain.Dtos.BaggageAllowance;
using FlightService.Domain.Models;
using FlightService.Services.BaggageAllowanceServices;
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
        [HttpGet]
        public async Task<IActionResult> GetAllBaggageAllowances()
        {
            var baggageAllowances = await _baggageAllowanceService.GetAllBaggageAllowances();
            return Ok(baggageAllowances);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBaggageAllowanceById(Guid id)
        {
            var baggageAllowance = await _baggageAllowanceService.GetBaggageAllowanceById(id);
            return Ok(baggageAllowance);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto)
        {
            var newBaggageAllowance = await _baggageAllowanceService.CreateBaggageAllowance(baggageAllowanceDto);
            return Ok(newBaggageAllowance);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBaggageAllowance(CreateBaggageAllowanceDto baggageAllowanceDto)
        {
            var updatedBaggageAllowance = await _baggageAllowanceService.UpdateBaggageAllowance(baggageAllowanceDto);
            return Ok(updatedBaggageAllowance);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBaggageAllowance(Guid id)
        {
            await _baggageAllowanceService.DeleteBaggageAllowance(id);
            return Ok();
        }

    }
}
