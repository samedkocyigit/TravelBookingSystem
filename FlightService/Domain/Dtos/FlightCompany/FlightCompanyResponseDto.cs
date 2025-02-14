namespace FlightService.Domain.Dtos.FlightCompany
{
    public class FlightCompanyResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Guid> FlightIds { get; set; } = new List<Guid>();
    }
}
