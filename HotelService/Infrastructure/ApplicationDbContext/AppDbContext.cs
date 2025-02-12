using HotelService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options ) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.HasMany(h => h.Floors)
                      .WithOne(fl => fl.Hotel )
                      .HasForeignKey(fl=>fl.HotelId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Floor>(entity => 
            {
                entity.HasKey(f => f.Id);
                entity.HasMany(f=> f.Rooms)
                      .WithOne(r=> r.Floor)
                      .HasForeignKey(r=>r.FloorId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(f => f.Facilities)
                      .WithOne(fa => fa.Floor)
                      .HasForeignKey(fa=> fa.FloorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
