using HotelService.Domain.Enums;
using HotelService.Models.Enums;

namespace HotelService.Models.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int RoomNumber { get; set; }
        public IsBooked IsBooked { get; set; } = IsBooked.Available;
        public Guid FloorId { get; set; }
        public Floor? Floor { get; set; }
    }
}
