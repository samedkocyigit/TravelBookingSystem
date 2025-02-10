namespace HotelService.Models.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AvailableRoom { get; set; }
        public int Stars { get; set; }
        public string Location { get; set; }

        public List<Floor>? Floors { get; set; } = new List<Floor>();
        public List<Facility>? Facilites { get; set; } = new List<Facility>();

    }
}
