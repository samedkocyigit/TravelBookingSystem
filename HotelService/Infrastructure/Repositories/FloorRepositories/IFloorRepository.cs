using HotelService.Models.Models;

namespace HotelService.Infrastructure.Repositories.FloorRepositories
{
    public interface IFloorRepository
    {
        Task<List<Floor>> GetAllFloors();
        Task<Floor> GetFloorById(Guid id);
        Task<Floor> CreateFloor(Floor floor);   
        Task<Floor> UpdateFloor(Floor floor);
        Task<Floor> DeleteFloor(Guid id);

    }
}
