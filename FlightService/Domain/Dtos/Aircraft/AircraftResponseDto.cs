namespace FlightService.Domain.Dtos.Aircraft
{
    public class AircraftResponseDto
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<Guid> FlightIds { get; set; } = new List<Guid>();
    }
}
