namespace PaymentService.Domain.Dtos
{
    public class PaymentCreationDto
    {
        public Guid UserToBeCharged { get; set; }
        public Guid BookingId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
    }
}
