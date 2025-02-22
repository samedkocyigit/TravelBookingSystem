namespace PaymentService.Domain.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; } 
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public decimal PaymentLimit { get; set; }
        public Guid UserId { get; set; }

    }
}
