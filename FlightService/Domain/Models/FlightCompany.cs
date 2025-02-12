namespace FlightService.Domain.Models
{
    public class FlightCompany
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
