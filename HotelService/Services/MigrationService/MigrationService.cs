using HotelService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Services.MigrationService
{
    public class MigrationService
    {
        public static void InitializeMigration(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope.ServiceProvider.GetService<AppDbContext>()!.Database.Migrate();
        }
    }
}
