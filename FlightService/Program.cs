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
<<<<<<< Updated upstream
using FlightService.Services.MigrationService;
=======
using FlightService.Services.SeatServices;
using FlightService.Services.TicketPriceServices;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
builder.Services.AddScoped<IFlightService, FlightsService>();
builder.Services.AddScoped<MigrationService>();
=======

builder.Services.AddScoped<IFlightService,FlightsService>();
builder.Services.AddScoped<ISeatService,SeatService>();
builder.Services.AddScoped<IAircraftService,AircraftService>();
builder.Services.AddScoped<IFlightCompanyService,FlightCompanyService>();
builder.Services.AddScoped<ITicketPriceService,TicketPriceService>();
builder.Services.AddScoped<IBaggageAllowanceService,BaggageAllowanceService>();
builder.Services.AddScoped<IAirportService,AirportService>();
>>>>>>> Stashed changes

var app = builder.Build();
MigrationService.InitializeMigration(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

