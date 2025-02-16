using AutoMapper;
using FlightService.Domain.Dtos.Aircraft;
using FlightService.Domain.Dtos.Airport;
using FlightService.Domain.Dtos.BaggageAllowance;
using FlightService.Domain.Dtos.Flight;
using FlightService.Domain.Dtos.FlightCompany;
using FlightService.Domain.Dtos.Seat;
using FlightService.Domain.Dtos.TicketPrice;
using FlightService.Domain.Models;

namespace FlightService.Services.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Flight, FlightResponseDto>()
                .ForMember(dest=> dest.AircraftModel, opt => opt.MapFrom(src => src.Aircraft.Model))
                .ForMember(dest=> dest.AircraftId, opt => opt.MapFrom(src => src.AircraftId))
                .ForMember(dest=> dest.FlightCompany, opt => opt.MapFrom(src => src.FlightCompany.Name))
                .ForMember(dest=> dest.FlightCompanyId, opt => opt.MapFrom(src => src.FlightCompanyId))
                .ForMember(dest=> dest.OriginAirport, opt => opt.MapFrom(src => src.OriginAirport.Name))
                .ForMember(dest=> dest.OriginAirportId, opt => opt.MapFrom(src => src.OriginAirportId))
                .ForMember(dest=> dest.DestinationAirport, opt => opt.MapFrom(src => src.DestinationAirport.Name))
                .ForMember(dest=> dest.DestinationAirportId, opt => opt.MapFrom(src => src.DestinationAirportId))
                .ForMember(dest=> dest.FlightNumber, opt => opt.MapFrom(src => src.FlightNumber))
                .ForMember(dest=> dest.DepartureTime, opt => opt.MapFrom(src => src.DepartureTime))
                .ForMember(dest=> dest.ArrivalTime, opt => opt.MapFrom(src => src.ArrivalTime))
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<Flight ,CreateFlightDto>()
                .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.FlightNumber))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.DepartureTime))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.ArrivalTime))
                .ForMember(dest => dest.OriginAirportId, opt => opt.MapFrom(src => src.OriginAirportId))
                .ForMember(dest => dest.DestinationAirportId, opt => opt.MapFrom(src => src.DestinationAirportId))
                .ForMember(dest => dest.AircraftId, opt => opt.MapFrom(src => src.AircraftId))
                .ForMember(dest => dest.FlightCompanyId, opt => opt.MapFrom(src => src.FlightCompanyId))
                .ReverseMap();

            CreateMap<Aircraft, AircraftResponseDto>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FlightIds, opt => opt.MapFrom(src => src.Flights.Select(f => f.Id)))
                .ReverseMap();
            CreateMap<Aircraft, CreateAircraftDto>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ReverseMap();
            
            CreateMap<Airport, AirportResponseDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ArrivingFlightIds, opt => opt.MapFrom(src => src.ArrivingFlights.Select(f => f.Id)))
                .ForMember(dest => dest.DepartingFlightIds, opt => opt.MapFrom(src => src.DepartingFlights.Select(f => f.Id)))
                .ForMember(dest => dest.IATACode, opt => opt.MapFrom(src => src.IATACode))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();
            CreateMap<Airport, CreateAirportDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IATACode, opt => opt.MapFrom(src => src.IATACode))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();

            CreateMap<BaggageAllowance, BaggageAllowanceResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ExtraChargePerKg, opt => opt.MapFrom(src => src.ExtraChargePerKg))
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.SeatClass))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.WeightLimitKg,opt => opt.MapFrom(src => src.WeightLimitKg))
                .ReverseMap();
            CreateMap<BaggageAllowance, CreateBaggageAllowanceDto>()
                .ForMember(dest => dest.ExtraChargePerKg, opt => opt.MapFrom(src => src.ExtraChargePerKg))
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.SeatClass))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.WeightLimitKg, opt => opt.MapFrom(src => src.WeightLimitKg))
                .ReverseMap();

            CreateMap<FlightCompany, FlightCompanyResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest=> dest.Code , opt => opt.MapFrom(src=> src.Code))
                .ForMember(dest => dest.FlightIds, opt => opt.MapFrom(src => src.Flights.Select(f => f.Id)))
                .ReverseMap();
            CreateMap<FlightCompany, CreateFlightCompanyDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ReverseMap();

            CreateMap<Seat,SeatResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.SeatClass))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => src.IsBooked))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.TicketPriceId, opt => opt.MapFrom(src => src.TicketPriceId))
                .ReverseMap();
            CreateMap<Seat, CreateSeatDto>()
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.SeatClass))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.TicketPriceId, opt => opt.MapFrom(src => src.TicketPriceId))
                .ReverseMap();

            CreateMap<TicketPrice, TicketPriceResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.SeatClass))
                .ReverseMap();
            CreateMap<TicketPrice, CreateTicketPriceDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.SeatClass))
                .ReverseMap();
        }
    }
}
