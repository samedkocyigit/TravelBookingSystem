namespace BookingService.Domain.Dtos
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int RoomNumber { get; set; }
        public string IsBooked { get; set; }
    }
}
