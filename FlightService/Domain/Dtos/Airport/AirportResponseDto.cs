namespace FlightService.Domain.Dtos.Airport
{
    public class AirportResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string IATACode { get; set; }
        public List<Guid> DepartingFlightIds { get; set; } = new List<Guid>();
        public List<Guid> ArrivingFlightIds { get; set; } = new List<Guid>();
    }
}
