using PaymentService.Domain.Enums;

namespace PaymentService.Domain.Models
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserToBeCharged { get; set; }
        public Guid BookingId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string PaymentMethod { get; set; } = "CreditCard";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
