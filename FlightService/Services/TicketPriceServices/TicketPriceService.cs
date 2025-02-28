using AutoMapper;
using FlightService.Domain.Dtos.TicketPrice;
using FlightService.Domain.Models;
using FlightService.Infrastructure.Repositories.TicketPriceRepositories;
using System.ComponentModel.DataAnnotations;

namespace FlightService.Services.TicketPriceServices
{
    public class TicketPriceService: ITicketPriceService
    {
        protected readonly ITicketPriceRepository _ticketPriceRepository;
        protected readonly IMapper _mapper;
        public TicketPriceService(ITicketPriceRepository ticketPriceRepository,IMapper mapper)
        {
            _ticketPriceRepository = ticketPriceRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketPriceResponseDto>> GetAllTicketPrices()
        {
            var ticketPrices = await _ticketPriceRepository.GetAllTicketPrices();
            var mappedTicketPrices = _mapper.Map<List<TicketPriceResponseDto>>(ticketPrices);
            return mappedTicketPrices;
        }
        public async Task<TicketPriceResponseDto> GetTicketPriceById(Guid id)
        {
            var ticketPrice = await _ticketPriceRepository.GetTicketPriceById(id);
            var mappedTicketPrice = _mapper.Map<TicketPriceResponseDto>(ticketPrice);
            return mappedTicketPrice;
        }
        public async Task<TicketPriceResponseDto> CreateTicketPrice(CreateTicketPriceDto ticketPriceDto)
        {
            if(ticketPriceDto.Price <= 0 || ticketPriceDto.SeatClass == null || ticketPriceDto.FlightId == Guid.Empty)
            {
                throw new ValidationException("Price, SeatClass and FlightId are required.");
            }
            var ticketPrice = _mapper.Map<TicketPrice>(ticketPriceDto);
            var newTicketPrice = await _ticketPriceRepository.CreateTicketPrice(ticketPrice);
            var mappedTicketPrice = _mapper.Map<TicketPriceResponseDto>(newTicketPrice);
            return mappedTicketPrice;
        }

        public async Task<TicketPriceResponseDto> UpdateTicketPrice(CreateTicketPriceDto ticketPriceDto)
        {
            var ticketPrice = _mapper.Map<TicketPrice>(ticketPriceDto);
            var updatedTicketPrice = await _ticketPriceRepository.UpdateTicketPrice(ticketPrice);
            var mappedTicketPrice = _mapper.Map<TicketPriceResponseDto>(updatedTicketPrice);
            return mappedTicketPrice;
        }

        public async Task DeleteTicketPrice(Guid id)
        {
            await _ticketPriceRepository.DeleteTicketPrice(id);
        }
    }
}
