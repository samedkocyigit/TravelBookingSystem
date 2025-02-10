using PaymentService.Domain.Enums;

namespace PaymentService.Domain.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }  
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "CreditCard";
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
