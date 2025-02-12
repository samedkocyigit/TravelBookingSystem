using FlightService.Infrastructure.ApplicationDbContext;
using FlightService.Infrastructure.Repositories.FlightRepository;
using FlightService.Services.FlightServices;
using FlightService.Services.MigrationService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();

builder.Services.AddScoped<IFlightService, FlightsService>();
builder.Services.AddScoped<MigrationService>();

var app = builder.Build();
MigrationService.InitializeMigration(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

