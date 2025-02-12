using HotelService.Models.Models;
using HotelService.Services.FacilityServices;
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
        [HttpGet]
        public async Task<IActionResult> GetAllFacilitys()
        {
            var facilities = await _facilityService.GetAllFacilities();
            return Ok(facilities);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFacilityById(Guid id)
        {
            var facility = await _facilityService.GetFacilityById(id);
            return Ok(facility);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFacility(Facility facility)
        {
            var newFacility = await _facilityService.CreateFacility(facility);
            return Ok(newFacility);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFacility(Facility facility)
        {
            var updatedFacility = await _facilityService.UpdateFacility(facility);
            return Ok(updatedFacility);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFacility(Guid id)
        {
            await _facilityService.DeleteFacility(id);
            return Ok();
        }
    }
}
