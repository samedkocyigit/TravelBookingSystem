namespace FlightService.Domain.Dtos.Flight
{
    public class CreateFlightDto
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Guid OriginAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public Guid AircraftId { get; set; }
        public Guid FlightCompanyId { get; set; }
    }
}
