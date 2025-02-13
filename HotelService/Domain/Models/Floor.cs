using System.Text.Json.Serialization;

namespace HotelService.Models.Models
{
    public class Floor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Hotel? Hotel { get; set; }
        public List<Room>? Rooms { get; set; } = new List<Room>();
        public List<Facility>? Facilities { get; set; } = new List<Facility>();
    }
}
