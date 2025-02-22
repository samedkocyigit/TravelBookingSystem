using Microsoft.EntityFrameworkCore;
using UserService.Domain.Models;
using UserService.Infrastructure.ApplicationDbContext;

namespace UserService.Infrastructure.Repositories.PaymentRepositories
{
    public class PaymentRepository : IPaymentRepository
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
        public async Task<Payment> GetPaymentById(Guid id)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Payment> CreatePayment(Payment Payment)
        {
            _context.Add(Payment);
            await _context.SaveChangesAsync();
            return Payment;
        }
        public async Task<Payment> UpdatePayment(Payment Payment)
        {
            _context.Update(Payment);
            await _context.SaveChangesAsync();
            return Payment;
        }
        public async Task DeletePaymentById(Guid id)
        {
            var Payment = await GetPaymentById(id);
            _context.Remove(Payment);
            await _context.SaveChangesAsync();
        }
    }
}
