using PaymentService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
