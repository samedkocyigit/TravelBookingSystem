using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.FacilityRepositories;
using HotelService.Models.Models;

namespace HotelService.Services.FacilityServices
{
    public class FacilityService:IFacilityService
    {
        protected readonly IFacilityRepository _facilityRepository;
        protected readonly IMapper _mapper;
        public FacilityService(IFacilityRepository facilityRepository,IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<List<Facility>> GetAllFacilities()
        {
            var facilitys = await _facilityRepository.GetAllFacilities();
            return facilitys;
        }
        public async Task<Facility> GetFacilityById(Guid id)
        {
            var facility = await _facilityRepository.GetFacilityById(id);
            return facility;
        }
        public async Task<Facility> CreateFacility(FacilityCreationDto facilityDto)
        {
            var mappedFacility = _mapper.Map<Facility>(facilityDto);
            var newFacility = await _facilityRepository.CreateFacility(mappedFacility);
            return newFacility;
        }

        public async Task<Facility> UpdateFacility(Facility facility)
        {
            var updatedFacility = await _facilityRepository.UpdateFacility(facility);
            return updatedFacility;
        }

        public async Task DeleteFacility(Guid id)
        {
            await _facilityRepository.DeleteFacilityById(id);
        }
    }
}
