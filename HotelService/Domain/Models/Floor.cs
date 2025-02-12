using System.Text.Json.Serialization;

namespace HotelService.Models.Models
{
    public class Floor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public List<Facility>? Facilities { get; set; } = new List<Facility>();
        public List<Room>? Rooms { get; set; } = new List<Room>();
        [JsonIgnore]
        public Hotel? Hotel { get; set; }
    }
}
