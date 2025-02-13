using Microsoft.EntityFrameworkCore;
using HotelService.Infrastructure.ApplicationDbContext;
using HotelService.Infrastructure.Repositories.FacilityRepositories;
using HotelService.Infrastructure.Repositories.FloorRepositories;
using HotelService.Infrastructure.Repositories.HotelRepositories;
using HotelService.Infrastructure.Repositories.RoomRepositories;
using HotelService.Services.FacilityServices;
using HotelService.Services.FloorServices;
using HotelService.Services.HotelServices;
using HotelService.Services.RoomServices;
using System.Reflection;
using HotelService.Services.MigrationService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IFloorRepository, FloorRepository>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IHotelService,HotelsService>();
builder.Services.AddScoped<IFloorService, FloorService>();
builder.Services.AddScoped<IFacilityService, FacilityService>();
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

