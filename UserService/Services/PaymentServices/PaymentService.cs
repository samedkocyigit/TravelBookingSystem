using AutoMapper;
using UserService.Domain.Dtos.PaymentDtos;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.PaymentRepositories;
using UserService.Infrastructure.Repositories.UserRepositories;

namespace UserService.Services.PaymentServices
{
    public class PaymentService: IPaymentService
    {
        protected readonly IPaymentRepository _paymentRepository;
        protected readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository,IUserRepository userRepository,IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
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
            var newPayment = await _paymentRepository.CreatePayment(mappedPayment);
            var user = await _userRepository.GetUserById(payment.UserId);
            user.Payments.Add(newPayment);
            await _userRepository.UpdateUser(user);
            return newPayment;
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
