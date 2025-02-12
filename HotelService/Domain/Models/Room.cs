using HotelService.Domain.Enums;
using HotelService.Models.Enums;
using System.Text.Json.Serialization;

namespace HotelService.Models.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public RoomType RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int RoomNumber { get; set; } 
        public IsBooked IsBooked { get; set; } = IsBooked.Available;
        public Guid FloorId { get; set; }
        [JsonIgnore]
        public Floor? Floor { get; set; }
    }
}
