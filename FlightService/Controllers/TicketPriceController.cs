using Microsoft.AspNetCore.Mvc;
using FlightService.Domain.Models;
using FlightService.Services.TicketPriceServices;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketPriceController : ControllerBase
    {
        private readonly ITicketPriceService _ticketPriceService;
        public TicketPriceController(ITicketPriceService ticketPriceService)
        {
            _ticketPriceService = ticketPriceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTicketPrices()
        {
            var ticketPrices = await _ticketPriceService.GetAllTicketPrices();
            return Ok(ticketPrices);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTicketPriceById(Guid id)
        {
            var ticketPrice = await _ticketPriceService.GetTicketPriceById(id);
            return Ok(ticketPrice);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicketPrice(TicketPrice ticketPrice)
        {
            var newTicketPrice = await _ticketPriceService.CreateTicketPrice(ticketPrice);
            return Ok(newTicketPrice);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicketPrice(TicketPrice ticketPrice)
        {
            var updatedTicketPrice = await _ticketPriceService.UpdateTicketPrice(ticketPrice);
            return Ok(updatedTicketPrice);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTicketPrice(Guid id)
        {
            await _ticketPriceService.DeleteTicketPrice(id);
            return Ok();
        }

    }
}
