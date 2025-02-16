namespace FlightService.Domain.Dtos.Airport
{
    public class CreateAirportDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string IATACode { get; set; }
    }
}
