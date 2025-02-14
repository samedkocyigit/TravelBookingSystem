namespace FlightService.Domain.Dtos.Flight
{
    public class FlightResponseDto
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string OriginAirport { get; set; }
        public Guid OriginAirportId { get; set; }

        public string DestinationAirport { get; set; }
        public Guid DestinationAirportId { get; set; }

        public string AircraftModel { get; set; }
        public Guid AircraftId { get; set; }

        public string FlightCompany { get; set; }
        public Guid FlightCompanyId { get; set; }
    }
}
