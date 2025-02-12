namespace FlightService.Domain.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public DateTime FlightTime { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        

    }
}
