using UserService.Domain.Models;

namespace PaymentService.Infrastructure.Repositories.PaymentRepositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(Guid id);
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task DeletePaymentById(Guid id);
    }
}
