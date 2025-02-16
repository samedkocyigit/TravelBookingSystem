using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Infrastructure.Repositories.FloorRepositories;
using HotelService.Models.Models;

namespace HotelService.Services.FloorServices
{
    public class FloorService:IFloorService
    {
        protected readonly IFloorRepository _floorRepository;
        protected readonly IMapper _mapper;

        public FloorService(IFloorRepository floorRepository,IMapper mapper)
        {
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<List<Floor>> GetAllFloors()
        {
            var floors = await _floorRepository.GetAllFloors();
            return floors;
        }
        public async Task<Floor> GetFloorById(Guid id)
        {
            var floor = await _floorRepository.GetFloorById(id);
            return floor;
        }
        public async Task<Floor> CreateFloor(FloorCreationDto floorDto)
        {
            var mappedFloor = _mapper.Map<Floor>(floorDto);
            var newFloor = await _floorRepository.CreateFloor(mappedFloor);
            return newFloor;
        }

        public async Task<Floor> UpdateFloor(Floor floor)
        {
            var updatedFloor = await _floorRepository.UpdateFloor(floor);
            return updatedFloor;
        }

        public async Task DeleteFloor(Guid id)
        {
            await _floorRepository.DeleteFloorById(id);
        }
    }
}
