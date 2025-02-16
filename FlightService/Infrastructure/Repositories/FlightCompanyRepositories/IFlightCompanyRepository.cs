using FlightService.Domain.Models;

namespace FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories
{
    public interface IFlightCompanyRepository
    {
        Task<List<FlightCompany>> GetAllFlightCompanies();
        Task<FlightCompany> GetFlightCompanyById(Guid id);
        Task<FlightCompany> CreateFlightCompany(FlightCompany flightCompany);
        Task<FlightCompany> UpdateFlightCompany(FlightCompany flightCompany);
        Task DeleteFlightCompany(Guid id);
    }
}
