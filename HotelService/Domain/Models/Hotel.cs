namespace HotelService.Models.Models
{
    public class Hotel
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string Name { get; set; }
        public int? RoomCapacity { get; set; }
        public int? AvailableRoom { get; set; }
        public int Stars { get; set; }
        public string Location { get; set; }

        public List<Guid>? ManagerIds { get; set; } = new List<Guid>();
        public List<Guid>? CustomerIds { get; set; } = new List<Guid>();
        public List<Floor>? Floors { get; set; } = new List<Floor>();
    }
}
