﻿using FlightService.Domain.Dtos.Flight;
using FlightService.Domain.Models;

namespace FlightService.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<FlightResponseDto>> GetAllFlights();
        Task<FlightResponseDto> GetFlightById(Guid id);
        Task<FlightResponseDto> CreateFlight(CreateFlightDto flightDto);
        Task<FlightResponseDto> UpdateFlight(CreateFlightDto flightDto);
        Task DeleteFlight(Guid id);
    }
}
