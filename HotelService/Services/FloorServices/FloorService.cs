using HotelService.Infrastructure.Repositories.FloorRepositories;
using HotelService.Models.Models;

namespace HotelService.Services.FloorServices
{
    public class FloorService:IFloorService
    {
        protected readonly IFloorRepository _floorRepository;
        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
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
        public async Task<Floor> CreateFloor(Floor floor)
        {
            var newFloor = await _floorRepository.CreateFloor(floor);
            return newFloor;
        }

        public async Task<Floor> UpdateFloor(Floor floor)
        {
            var updatedFloor = await _floorRepository.UpdateFloor(floor);
            return updatedFloor;
        }

        public async Task DeleteFloor(Guid id)
        {
            await _floorRepository.GetFloorById(id);
        }
    }
}
