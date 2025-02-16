using BookingService.Domain.Dtos;
using Newtonsoft.Json;

namespace BookingService.Services.RoomService
{
    public class RoomService:IRoomService
    {
        protected readonly HttpClient _httpClient;
        public RoomService( HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<List<HotelDto>> GetAvailableRoomsFromHotelService()
        {
            var response = await _httpClient.GetAsync("http://hotelservice:8080/api/Hotel/available-rooms");

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
