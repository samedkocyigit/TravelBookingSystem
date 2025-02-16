using FlightService.Domain.Dtos.FlightCompany;
using FlightService.Domain.Models;

namespace FlightService.Services.FlightCompanyServices
{
    public interface IFlightCompanyService
    {
        Task<List<FlightCompanyResponseDto>> GetAllFlightCompanies();
        Task<FlightCompanyResponseDto> GetFlightCompanyById(Guid id);
        Task<FlightCompanyResponseDto> CreateFlightCompany(CreateFlightCompanyDto flightCompanyDto);
        Task<FlightCompanyResponseDto> UpdateFlightCompany(CreateFlightCompanyDto flightCompanyDto);
        Task DeleteFlightCompany(Guid id);
    }
}
