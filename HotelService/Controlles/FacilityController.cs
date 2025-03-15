using HotelService.Domain.Dtos;
using HotelService.Models.Models;
using HotelService.Services.FacilityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilityController:ControllerBase
    {
        private readonly IFacilityService _facilityService;
        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        //get all facilities
        [HttpGet]
        public async Task<IActionResult> GetAllFacilitys()
        {
            var facilities = await _facilityService.GetAllFacilities();
            return Ok(facilities);
        }

        //get facility by id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFacilityById(Guid id)
        {
            var facility = await _facilityService.GetFacilityById(id);
            return Ok(facility);
        }

        //creation facility
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateFacility(FacilityCreationDto facilityDto)
        {
            var newFacility = await _facilityService.CreateFacility(facilityDto);
            return Ok(newFacility);
        }

        //update facility
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateFacility(Facility facility)
        {
            var updatedFacility = await _facilityService.UpdateFacility(facility);
            return Ok(updatedFacility);
        }

        //delete facility with id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFacility(Guid id)
        {
            await _facilityService.DeleteFacility(id);
            return Ok();
        }
    }
}
