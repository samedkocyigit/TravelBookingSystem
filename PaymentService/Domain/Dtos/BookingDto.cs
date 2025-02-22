namespace PaymentService.Domain.Dtos
{
    public class BookingDto
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
        public Guid RoomId { get; set; }
        public int BookingDateDay { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatus Status { get; set; }
    }
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
