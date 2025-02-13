using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories;

namespace FlightService.Services.FlightCompanyServices
{
    public class FlightCompanyService: IFlightCompanyService
    {
        protected readonly IFlightCompanyRepository _flightCompanyRepository;
        public FlightCompanyService(IFlightCompanyRepository flightCompanyRepository)
        {
            _flightCompanyRepository = flightCompanyRepository;
        }

        public async Task<List<FlightCompany>> GetAllFlightCompanies()
        {
            var flightCompanies = await _flightCompanyRepository.GetAllFlightCompanies();
            return flightCompanies;
        }
        public async Task<FlightCompany> GetFlightCompanyById(Guid id)
        {
            var flightCompany = await _flightCompanyRepository.GetFlightCompanyById(id);
            return flightCompany;
        }
        public async Task<FlightCompany> CreateFlightCompany(FlightCompany flightCompany)
        {
            var newFlightCompany = await _flightCompanyRepository.CreateFlightCompany(flightCompany);
            return newFlightCompany;
        }

        public async Task<FlightCompany> UpdateFlightCompany(FlightCompany flightCompany)
        {
            var updatedFlightCompany = await _flightCompanyRepository.UpdateFlightCompany(flightCompany);
            return updatedFlightCompany;
        }

        public async Task DeleteFlightCompany(Guid id)
        {
            await _flightCompanyRepository.DeleteFlightCompany(id);
        }
    }
}
