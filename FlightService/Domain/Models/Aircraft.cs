namespace FlightService.Domain.Models
{
    public class Aircraft
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Model  { get; set; }
        public int  Capacity { get; set; }
        public List<Flight>?  Flights { get; set; } = new List<Flight>();    
    }
}
