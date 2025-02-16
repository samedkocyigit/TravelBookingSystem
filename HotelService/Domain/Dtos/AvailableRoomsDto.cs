namespace HotelService.Domain.Dtos
{
    public class AvailableRoomsDto
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public int HotelStars { get; set; }
        public string HotelLocation { get; set; } 
        public List<AvailableRoomDto> Rooms { get; set; } = new List<AvailableRoomDto>();
    }
}
