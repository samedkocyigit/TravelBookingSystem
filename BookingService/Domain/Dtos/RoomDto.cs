namespace BookingService.Domain.Dtos
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int RoomNumber { get; set; }
        public int IsBooked { get; set; }
    }
}
