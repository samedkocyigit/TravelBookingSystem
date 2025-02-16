using System.Text.Json.Serialization;

namespace FlightService.Domain.Models
{
    public class FlightCompany
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Flight>? Flights { get; set; } = new List<Flight>();   
    }
}
