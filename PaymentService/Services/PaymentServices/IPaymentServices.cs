using PaymentService.Domain.Dtos;
using PaymentService.Domain.Models;

namespace PaymentService.Services.PaymentServices
{
    public interface IPaymentServices
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(Guid id);
        Task<Payment> CreatePayment(PaymentCreationDto payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task DeletePayment(Guid id);
    }
}
