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
using FlightService.Services.MigrationService;
using FlightService.Services.SeatServices;
using FlightService.Services.TicketPriceServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "User API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer <your-token>'",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["JwtSettings:Issuer"];
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"])),
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightCompanyRepository,FlightCompanyRepository>();
builder.Services.AddScoped<ISeatRepository,SeatRepository>();
builder.Services.AddScoped<IAircraftRepository,AircraftRepository>();
builder.Services.AddScoped<IAirportRepository,AirportRepository>();
builder.Services.AddScoped<IBaggageAllowanceRepository,BaggageAllowanceRepository>();
builder.Services.AddScoped<ITicketPriceRepository,TicketPriceRepository>();


builder.Services.AddScoped<IFlightService,FlightsService>();
builder.Services.AddScoped<ISeatService,SeatService>();
builder.Services.AddScoped<IAircraftService,AircraftService>();
builder.Services.AddScoped<IFlightCompanyService,FlightCompanyService>();
builder.Services.AddScoped<ITicketPriceService,TicketPriceService>();
builder.Services.AddScoped<IBaggageAllowanceService,BaggageAllowanceService>();
builder.Services.AddScoped<IAirportService,AirportService>();
builder.Services.AddScoped<MigrationService>();

var app = builder.Build();
MigrationService.InitializeMigration(app);

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

