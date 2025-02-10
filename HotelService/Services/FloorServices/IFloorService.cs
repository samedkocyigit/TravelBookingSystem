using HotelService.Models.Models;

namespace HotelService.Services.FloorServices
{
    public interface IFloorService
    {
        Task<List<Floor>> GetAllFloors();
        Task<Floor> GetFloorById(Guid id);
        Task<Floor> CreateFloor(Floor floor);
        Task<Floor> UpdateFloor(Floor floor);
        Task DeleteFloor(Guid id);
    }
}
