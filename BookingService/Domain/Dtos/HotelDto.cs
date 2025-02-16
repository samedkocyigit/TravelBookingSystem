namespace BookingService.Domain.Dtos
{
    public class HotelDto
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public int HotelStars { get; set; }
        public string HotelLocation { get; set; }
        public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();
    }

    

}
