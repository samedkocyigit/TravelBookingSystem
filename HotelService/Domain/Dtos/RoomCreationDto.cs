using HotelService.Models.Enums;

namespace HotelService.Domain.Dtos
{
    public class RoomCreationDto
    {
        public Guid floorId { get; set; }
        public RoomType roomType { get; set; }
    }
}
