using HotelService.Models.Enums;

namespace HotelService.Domain.Dtos
{
    public class RoomCreationDto
    {
        public RoomType roomType  { get; set; }
        public Guid floorId { get; set; }
    }
}
