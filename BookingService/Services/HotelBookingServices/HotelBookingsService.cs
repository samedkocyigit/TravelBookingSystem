﻿using BookingService.Domain.Dtos;
using BookingService.Domain.Models;
using BookingService.Infrastructure.Repositories.HotelBookingRepositories;
using Newtonsoft.Json;
using System.Text;

namespace BookingService.Services.HotelBookingServices
{
    public class HotelBookingsService:IHotelBookingServices
    {
        protected readonly IHotelBookingRepository _bookingRepository;
        protected readonly HttpClient _httpClient;
        public HotelBookingsService(IHotelBookingRepository bookingRepository, IHttpClientFactory httpClientFactory)
        {
            _bookingRepository = bookingRepository;
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<List<HotelBooking>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookings();
            return bookings;
        }
        public async Task<HotelBooking> GetBookingById(Guid id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return booking;
        }
        public async Task<HotelBooking> CreateBooking(HotelBooking booking)
        {
            var res = await _httpClient.PutAsync($"http://hotelservice:8080/api/room/book/{booking.RoomId}/{booking.UserId}",null);
            
            if (!res.IsSuccessStatusCode)
                throw new Exception("Failed to book the room.");
            
            var room = await res.Content.ReadFromJsonAsync<RoomDto>();
            booking.TotalAmount = booking.BookingDateDay * room.PricePerNight;
            
            var newBooking = await _bookingRepository.CreateBooking(booking);
            return newBooking;
        }
        public async Task<HotelBooking> UpdateBooking(HotelBooking booking)
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
