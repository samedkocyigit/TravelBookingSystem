namespace UserService.Domain.Dtos.PaymentDtos
{
    public class PaymentCreateDto
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public Guid UserId { get; set; }
    }
}
