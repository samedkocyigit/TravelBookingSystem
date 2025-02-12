namespace FlightService.Domain.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Guid OriginAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public Guid AircraftId { get; set; }
        public Guid FlightCompanyId { get; set; }
        public Aircraft Aircraft { get; set; }
        public FlightCompany FlightCompany { get; set; }
        public Airport Airport { get; set; }
        public List<Seat>? Seats { get; set; } = new List<Seat>();
        public List<TicketPrice>? TicketPrices { get; set; } = new List<TicketPrice>();
        public List<BaggageAllowance>? BaggageAllowances { get; set; } = new List<BaggageAllowance>();
    }
}
