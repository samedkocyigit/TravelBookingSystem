using BookingService.Domain.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BookingService.Services.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<HotelDto>> GetAvailableRoomsFromHotelService()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, "http://hotelservice:8080/api/Hotel/available-rooms");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", ""));
            }

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var hotelList = JsonConvert.DeserializeObject<List<HotelDto>>(jsonString);
                return hotelList;
            }

            return new List<HotelDto>();
        }
    }
}
