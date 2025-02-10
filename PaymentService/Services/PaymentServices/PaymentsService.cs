using PaymentService.Domain.Models;
using PaymentService.Infrastructure.Repositories.PaymentRepositories;

namespace PaymentService.Services.PaymentServices
{
    public class PaymentsService:IPaymentServices
    {
        protected readonly IPaymentRepository _paymentRepository;
        public PaymentsService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
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
        public async Task<Payment> CreatePayment(Payment payment)
        {
            var newPayment = await _paymentRepository.CreatePayment(payment);
            return newPayment;
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
