using AutoMapper;
using PaymentService.Domain.Dtos;
using PaymentService.Domain.Models;
using PaymentService.Infrastructure.Repositories.PaymentRepositories;

namespace PaymentService.Services.PaymentServices
{
    public class PaymentsService:IPaymentServices
    {
        protected readonly IPaymentRepository _paymentRepository;
        protected readonly IMapper _mapper;
        protected readonly HttpClient _httpClient;
        public PaymentsService(IMapper mapper,IPaymentRepository paymentRepository, HttpClient httpClient)
        {
            _paymentRepository = paymentRepository;
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<Payment>> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllPayments();
            return payments;
        }
        public async Task<Payment> GetPaymentById(Guid id)
        {
            var payment = await _paymentRepository.GetPaymentById(id);
            return payment;
        }
        public async Task<Payment> CreatePayment(PaymentCreationDto payment)
        {
            // Validate user information
            var resUser = await _httpClient.GetAsync($"http://userservice:8080/api/User/{payment.UserToBeCharged}");
            if (!resUser.IsSuccessStatusCode)
                throw new Exception("Failed to retrieve user information");

            var user = await resUser.Content.ReadFromJsonAsync<UserDto>() ?? throw new Exception("User not found");

            // Validate booking information
            var resBooking = await _httpClient.GetAsync($"http://bookingservice:8080/api/HotelBooking/{payment.BookingId}");
            if (!resBooking.IsSuccessStatusCode)
                throw new Exception("Failed to retrieve booking information");

            var booking = await resBooking.Content.ReadFromJsonAsync<BookingDto>() ?? throw new Exception("Booking not found");

            // Ensure user has at least one payment method
            if (user.Payments == null || user.Payments.Count == 0)
                throw new Exception("No payment methods available");

            var userPayment = user.Payments.First();

            // Validate payment details
            var fullName = (user.Name + user.Surname).Replace(" ", "").ToLower();
            var cardHolderName = payment.CardHolderName.Replace(" ", "").ToLower();

            if (userPayment.PaymentLimit < booking.TotalAmount ||
                payment.CVV != userPayment.CVV ||
                payment.CardNumber != userPayment.CardNumber ||
                payment.ExpiryDate != userPayment.ExpiryDate ||
                cardHolderName != fullName)
            {
                throw new Exception("Invalid Payment Details");
            }

            // Deduct payment amount and update booking
            userPayment.PaymentLimit -= booking.TotalAmount;
            booking.Status = BookingStatus.Confirmed;

            // Update user and booking concurrently
            var updateUserTask = _httpClient.PutAsJsonAsync($"http://userservice:8080/api/User/afterPayment", user);
            var updateBookingTask = _httpClient.PutAsJsonAsync($"http://bookingservice:8080/api/HotelBooking", booking);

            await Task.WhenAll(updateUserTask, updateBookingTask);

            if (!updateUserTask.Result.IsSuccessStatusCode || !updateBookingTask.Result.IsSuccessStatusCode)
                throw new Exception("Failed to update user or booking information");

            // Map and create new payment record
            var mappedPayment = _mapper.Map<Payment>(payment);
            return await _paymentRepository.CreatePayment(mappedPayment);
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            var updatedPayment = await _paymentRepository.UpdatePayment(payment);
            return updatedPayment;
        }

        public async Task DeletePayment(Guid id)
        {
            await _paymentRepository.DeletePayment(id);
        }

        
    }
}
