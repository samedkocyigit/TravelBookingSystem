using BookingService.Domain.Enums;

namespace BookingService.Domain.Models
{
    public class FlightBooking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }  
        public Guid? FlightId { get; set; }  
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}
