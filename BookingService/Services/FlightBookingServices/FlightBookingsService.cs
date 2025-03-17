using BookingService.Domain.Models;
using BookingService.Infrastructure.Repositories.FlightBookingRepositories;
using System.Net.Http.Headers;

namespace BookingService.Services.FlightBookingServices
{
    public class FlightBookingsService:IFlightBookingServices
    {
        protected readonly IFlightBookingRepository _bookingRepository;
        protected readonly HttpClient _httpClient;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public FlightBookingsService(IFlightBookingRepository bookingRepository, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _bookingRepository = bookingRepository;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<FlightBooking>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookings();
            return bookings;
        }
        public async Task<FlightBooking> GetBookingById(Guid id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return booking;
        }
        //public async Task<Flights> GetAvailableFlights(string fromWhere, string toWhere)
        //{
        //    var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
        //    if (string.IsNullOrEmpty(token))
        //        throw new Exception("Unauthorized");

        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", ""));

        //    var res = await _httpClient.GetAsync($"http://flightservice:8080/api/flight/available-flights/{fromWhere}/{toWhere}");
        //    var flights = await _bookingRepository.GetAvailableFlights(fromWhere, toWhere);
        //    return flights;
        //}
        public async Task<FlightBooking> CreateBooking(FlightBooking booking)
        {
            var newBooking = await _bookingRepository.CreateBooking(booking);
            return newBooking;
        }
        public async Task<FlightBooking> UpdateBooking(FlightBooking booking)
        {
            var updatedBooking = await _bookingRepository.UpdateBooking(booking);
            return updatedBooking;
        }

        public async Task DeleteBooking(Guid id)
        {
            await _bookingRepository.DeleteBooking(id);
        }

        
    }
}
