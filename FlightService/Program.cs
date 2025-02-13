using FlightService.Infrastructure.ApplicationDbContext;
using FlightService.Infrastructure.Repositories.AircraftRepositories;
using FlightService.Infrastructure.Repositories.AirportRepositories;
using FlightService.Infrastructure.Repositories.BaggageAllowanceRepositories;
using FlightService.Infrastructure.Repositories.FlightCompanyCompanyRepositories;
using FlightService.Infrastructure.Repositories.FlightRepositories;
using FlightService.Infrastructure.Repositories.SeatRepositories;
using FlightService.Infrastructure.Repositories.TicketPriceRepositories;
using FlightService.Services.AircraftServices;
using FlightService.Services.AirportServices;
using FlightService.Services.BaggageAllowanceServices;
using FlightService.Services.FlightCompanyServices;
using FlightService.Services.FlightServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightCompanyRepository,FlightCompanyRepository>();
builder.Services.AddScoped<ISeatRepository,SeatRepository>();
builder.Services.AddScoped<IAircraftRepository,AircraftRepository>();
builder.Services.AddScoped<IAirportRepository,AirportRepository>();
builder.Services.AddScoped<IBaggageAllowanceRepository,BaggageAllowanceRepository>();
builder.Services.AddScoped<ITicketPriceRepository,TicketPriceRepository>();


builder.Services.AddScoped<IFlightService, FlightsService>();

var app = builder.Build();
MigrationService.InitializeMigration(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

