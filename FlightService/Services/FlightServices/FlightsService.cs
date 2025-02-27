using AutoMapper;
using FlightService.Domain.Dtos.Flight;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.AircraftRepositories;
using FlightService.Infrastructure.Repositories.AirportRepositories;
using FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories;
using FlightService.Infrastructure.Repositories.FlightRepositories;

namespace FlightService.Services.FlightServices
{
    public class FlightsService: IFlightService
    {
        protected readonly IFlightRepository _flightRepository;
        protected readonly IAircraftRepository _aircraftRepository;
        protected readonly IAirportRepository _airportRepository;
        protected readonly IFlightCompanyRepository _flightCompanyRepository;
        protected readonly IMapper _mapper;
        public FlightsService(IFlightRepository flightRepository,IAirportRepository airportRepository,IAircraftRepository aircraftRepository,IFlightCompanyRepository flightCompanyRepository , IMapper mapper)
        {
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
            _aircraftRepository = aircraftRepository;
            _flightCompanyRepository = flightCompanyRepository;
            _mapper = mapper;
        }

        public async Task<List<FlightResponseDto>> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlights();
            var mappedFlights = _mapper.Map<List<FlightResponseDto>>(flights);
            return mappedFlights;
        }
        public async Task<List<FlightResponseDto>> GetAvailableFlights(string fromWhere, string toWhere)
        {
            var flights = await _flightRepository.GetAvailableFlights(fromWhere, toWhere);
            var mappedFlights = _mapper.Map<List<FlightResponseDto>>(flights);
            return mappedFlights;
        }
        public async Task<FlightResponseDto> GetFlightById(Guid id)
        {
            var flight = await _flightRepository.GetFlightById(id);
            var mappedFlight = _mapper.Map<FlightResponseDto>(flight);
            return mappedFlight;
        }
        public async Task<FlightResponseDto> CreateFlight(CreateFlightDto flightDto)
        {
            Console.WriteLine($"CreateDto flight from {flightDto.OriginAirportId} to {flightDto.DestinationAirportId}");
            var flight = _mapper.Map<Flight>(flightDto);
            Console.WriteLine($"Mapped flight from {flight.OriginAirportId} to {flight.DestinationAirportId}");

            var flightCompany = await _flightCompanyRepository.GetFlightCompanyById(flight.FlightCompanyId);
            var aircraft = await _aircraftRepository.GetAircraftById(flight.AircraftId);
            var departureAirport = await _airportRepository.GetAirportById(flight.OriginAirportId);
            Console.WriteLine($"Departure airport: {departureAirport.Name}");
            var arrivalAirport = await _airportRepository.GetAirportById(flight.DestinationAirportId);
            Console.WriteLine($"Arrival airport: {arrivalAirport.Name}");

            var newFlight = await _flightRepository.CreateFlight(flight);
            Console.WriteLine($"New flight from {newFlight.OriginAirportId} to {newFlight.DestinationAirportId}");

            flightCompany.Flights.Add(newFlight);
            aircraft.Flights.Add(newFlight);
            departureAirport.ArrivingFlights.Add(newFlight);
            arrivalAirport.DepartingFlights.Add(newFlight);

            await _flightCompanyRepository.UpdateFlightCompany(flightCompany);
            await _aircraftRepository.UpdateAircraft(aircraft);
            await _airportRepository.UpdateAirport(departureAirport);
            await _airportRepository.UpdateAirport(arrivalAirport);

            var mappedFlight = _mapper.Map<FlightResponseDto>(newFlight);
            return mappedFlight;
        }

        public async Task<FlightResponseDto> UpdateFlight(CreateFlightDto flightDto)
        {
            var flight = _mapper.Map<Flight>(flightDto);
            var updatedFlight = await _flightRepository.UpdateFlight(flight);
            var mappedFlight = _mapper.Map<FlightResponseDto>(updatedFlight);
            return mappedFlight;
        }

        public async Task DeleteFlight(Guid id)
        {
            var flight = await _flightRepository.GetFlightById(id);
            var flightCompany = await _flightCompanyRepository.GetFlightCompanyById(flight.FlightCompanyId);
            var aircraft = await _aircraftRepository.GetAircraftById(flight.AircraftId);
            var departureAirport = await _airportRepository.GetAirportById(flight.OriginAirportId);
            var arrivalAirport = await _airportRepository.GetAirportById(flight.DestinationAirportId);

            flightCompany.Flights.Remove(flight);
            aircraft.Flights.Remove(flight);
            departureAirport.ArrivingFlights.Remove(flight);
            arrivalAirport.DepartingFlights.Remove(flight);

            await _flightRepository.DeleteFlight(id);
            await _flightCompanyRepository.UpdateFlightCompany(flightCompany);
            await _aircraftRepository.UpdateAircraft(aircraft);
            await _airportRepository.UpdateAirport(departureAirport);
            await _airportRepository.UpdateAirport(arrivalAirport);

        }
    }
}
