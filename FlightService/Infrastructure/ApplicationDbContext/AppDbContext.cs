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
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }
        public DbSet<BaggageAllowance> BaggageAllowances { get; set; }
        public DbSet<FlightCompany> FlightCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.HasOne(f => f.OriginAirport)
                    .WithMany(a=>a.DepartingFlights)
                    .HasForeignKey(f => f.OriginAirportId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(f => f.DestinationAirport)
                    .WithMany(a=>a.ArrivingFlights)
                    .HasForeignKey(f => f.DestinationAirportId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(f => f.Aircraft)
                    .WithMany(a=>a.Flights)
                    .HasForeignKey(f => f.AircraftId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(f => f.Seats)
                    .WithOne(s=>s.Flight)
                    .HasForeignKey(s => s.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(f => f.TicketPrices)
                    .WithOne(tp=>tp.Flight)
                    .HasForeignKey(tp => tp.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(f => f.BaggageAllowances)
                    .WithOne(ba=>ba.Flight)
                    .HasForeignKey(ba => ba.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(f => f.FlightCompany)
                    .WithMany(fc => fc.Flights)
                    .HasForeignKey(f => f.FlightCompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasMany(a => a.DepartingFlights)
                    .WithOne(f=>f.OriginAirport)
                    .HasForeignKey(f => f.OriginAirportId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(a => a.ArrivingFlights)
                    .WithOne(f=>f.DestinationAirport)
                    .HasForeignKey(f => f.DestinationAirportId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasMany(a => a.Flights)
                    .WithOne(f=>f.Aircraft)
                    .HasForeignKey(f => f.AircraftId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Seat>(entity => 
            {
                entity.HasKey(s => s.Id);
                entity.HasOne(s => s.Flight)
                    .WithMany(f=>f.Seats)
                    .HasForeignKey(s => s.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(s => s.SeatClass)
                    .HasConversion<string>();
                entity.Property(s => s.IsBooked)
                    .HasConversion<string>();
            });
            modelBuilder.Entity<TicketPrice>(entity =>
            {
                entity.HasKey(tp => tp.Id);
                entity.HasOne(tp => tp.Flight)
                    .WithMany(f=>f.TicketPrices)
                    .HasForeignKey(tp => tp.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(tp => tp.SeatClass)
                    .HasConversion<string>();
            });
            modelBuilder.Entity<BaggageAllowance>(entity =>
            {
                entity.HasKey(ba => ba.Id);
                entity.HasOne(ba => ba.Flight)
                    .WithMany(f=>f.BaggageAllowances)
                    .HasForeignKey(ba => ba.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(ba => ba.SeatClass)
                    .HasConversion<string>();
            });
            modelBuilder.Entity<FlightCompany>(entity =>
            {
                entity.HasKey(fc => fc.Id);
                entity.HasMany(fc => fc.Flights)
                    .WithOne(f=>f.FlightCompany)
                    .HasForeignKey(f => f.FlightCompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
