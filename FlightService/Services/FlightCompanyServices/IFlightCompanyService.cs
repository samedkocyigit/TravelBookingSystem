using FlightService.Domain.Models;

namespace FlightService.Services.FlightCompanyServices
{
    public interface IFlightCompanyService
    {
        Task<List<FlightCompany>> GetAllFlightCompanies();
        Task<FlightCompany> GetFlightCompanyById(Guid id);
        Task<FlightCompany> CreateFlightCompany(FlightCompany flightCompany);
        Task<FlightCompany> UpdateFlightCompany(FlightCompany flightCompany);
        Task DeleteFlightCompany(Guid id);
    }
}
