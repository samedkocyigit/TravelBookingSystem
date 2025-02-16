namespace FlightService.Domain.Models
{
    public class Airport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Location { get; set; }
        public string IATACode { get; set; }    

        public List<Flight>? DepartingFlights { get; set; } = new List<Flight>();    
        public List<Flight>? ArrivingFlights { get; set; } = new List<Flight>();

    }
}