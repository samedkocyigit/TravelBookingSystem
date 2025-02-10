using FlightService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
