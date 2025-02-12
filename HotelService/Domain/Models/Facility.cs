using System.Text.Json.Serialization;

namespace HotelService.Models.Models
{
    public class Facility
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FloorId { get; set; }
        [JsonIgnore]
        public Floor? Floor { get; set; }
    }
}
