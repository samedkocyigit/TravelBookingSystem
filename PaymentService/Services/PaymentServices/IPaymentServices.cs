using PaymentService.Domain.Models;

namespace PaymentService.Services.PaymentServices
{
    public interface IPaymentServices
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(Guid id);
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task DeletePayment(Guid id);
    }
}
