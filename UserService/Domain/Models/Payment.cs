using System.Text.Json.Serialization;

namespace UserService.Domain.Models
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CardNumber { get; set; }  
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public decimal PaymentLimit { get; set; } = 10000;
        public Guid UserId { get; set; }
        [JsonIgnore]    
        public User? User { get; set; }
    }
}
