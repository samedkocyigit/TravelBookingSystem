using BookingService.Domain.Enums;

namespace BookingService.Domain.Models
{
    public class HotelBooking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
        public Guid RoomId { get; set; }
        public int BookingDateDay { get; set; } 
        public decimal? TotalAmount { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}
