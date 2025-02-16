using BookingService.Infrastructure.ApplicationDbContext;
using BookingService.Infrastructure.Repositories.FlightBookingRepositories;
using BookingService.Infrastructure.Repositories.HotelBookingRepositories;
using BookingService.Services.FlightBookingServices;
using BookingService.Services.HotelBookingServices;
using BookingService.Services.MigrationService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
builder.Services.AddScoped<IHotelBookingServices, HotelBookingsService>();
builder.Services.AddScoped<IFlightBookingServices, FlightBookingsService>();
builder.Services.AddScoped<MigrationService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
MigrationService.InitializeMigration(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
