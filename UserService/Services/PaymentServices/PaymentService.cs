using AutoMapper;
using PaymentService.Infrastructure.Repositories.PaymentRepositories;
using UserService.Domain.Dtos.Payment;
using UserService.Domain.Models;

namespace UserService.Services.PaymentServices
{
    public class PaymentService
    {
        protected readonly IPaymentRepository _paymentRepository;
        public readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository,IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task<List<Payment>> GetAllPayments()
        {
            return await _paymentRepository.GetAllPayments();
        }
        public async Task<Payment> GetPaymentById(Guid id)
        {
            return await _paymentRepository.GetPaymentById(id);
        }
        public async Task<Payment> CreatePayment(PaymentCreateDto payment)
        {
            var mappedPayment = _mapper.Map<Payment>(payment);
            return await _paymentRepository.CreatePayment(mappedPayment);
        }
        public async Task<Payment> UpdatePayment(Payment payment)
        {
            return await _paymentRepository.UpdatePayment(payment);
        }
        public async Task DeletePayment(Guid id)
        {
            await _paymentRepository.DeletePaymentById(id);
        }
    }
}
