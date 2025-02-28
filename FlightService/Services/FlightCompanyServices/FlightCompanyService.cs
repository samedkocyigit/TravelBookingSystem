using AutoMapper;
using FlightService.Domain.Dtos.FlightCompany;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories;
using System.ComponentModel.DataAnnotations;

namespace FlightService.Services.FlightCompanyServices
{
    public class FlightCompanyService: IFlightCompanyService
    {
        protected readonly IFlightCompanyRepository _flightCompanyRepository;
        protected readonly IMapper _mapper;
        public FlightCompanyService(IFlightCompanyRepository flightCompanyRepository,IMapper mapper)
        {
            _flightCompanyRepository = flightCompanyRepository;
            _mapper = mapper;
        }

        public async Task<List<FlightCompanyResponseDto>> GetAllFlightCompanies()
        {
            var flightCompanies = await _flightCompanyRepository.GetAllFlightCompanies();
            var mappedFlightCompanies = _mapper.Map<List<FlightCompanyResponseDto>>(flightCompanies);
            return mappedFlightCompanies;
        }
        public async Task<FlightCompanyResponseDto> GetFlightCompanyById(Guid id)
        {
            var flightCompany = await _flightCompanyRepository.GetFlightCompanyById(id);
            var mappedFlightCompany = _mapper.Map<FlightCompanyResponseDto>(flightCompany);
            return mappedFlightCompany;
        }
        public async Task<FlightCompanyResponseDto> CreateFlightCompany(CreateFlightCompanyDto flightCompanyDto)
        {
            if(flightCompanyDto.Code.Length != 3 || string.IsNullOrEmpty(flightCompanyDto.Name))
            {
                throw new ValidationException("Name is required and Code must be 2 characters long.");
            }
            var flightCompany = _mapper.Map<FlightCompany>(flightCompanyDto);
            var newFlightCompany = await _flightCompanyRepository.CreateFlightCompany(flightCompany);
            var mappedFlightCompany = _mapper.Map<FlightCompanyResponseDto>(newFlightCompany);
            return mappedFlightCompany;
        }

        public async Task<FlightCompanyResponseDto> UpdateFlightCompany(CreateFlightCompanyDto flightCompanyDto)
        {
            var flightCompany = _mapper.Map<FlightCompany>(flightCompanyDto);
            var updatedFlightCompany = await _flightCompanyRepository.UpdateFlightCompany(flightCompany);
            var mappedFlightCompany = _mapper.Map<FlightCompanyResponseDto>(updatedFlightCompany);
            return mappedFlightCompany;
        }

        public async Task DeleteFlightCompany(Guid id)
        {
            await _flightCompanyRepository.DeleteFlightCompany(id);
        }
    }
}
