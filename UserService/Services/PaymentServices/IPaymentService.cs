using UserService.Domain.Dtos.Payment;
using UserService.Domain.Models;

namespace UserService.Services.PaymentServices
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(Guid id);
        Task<Payment> CreatePayment(PaymentCreateDto payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task DeletePayment(Guid id);

    }
}
