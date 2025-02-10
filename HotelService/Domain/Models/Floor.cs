namespace HotelService.Models.Models
{
    public class Floor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
