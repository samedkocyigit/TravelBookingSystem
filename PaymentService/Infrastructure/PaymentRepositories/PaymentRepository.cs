using PaymentService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BookingService.Infrastructure.ApplicationDbContext;

namespace PaymentService.Infrastructure.Repositories.PaymentRepositories
{
    public class PaymentRepository:IPaymentRepository
    {
        protected readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment?> GetPaymentById(Guid id)
        {
            return await _context.Payments.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        public async Task DeletePayment(Guid id)
        {
            var payment = await GetPaymentById(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }
    }
}
