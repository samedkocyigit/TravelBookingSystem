using BookingService.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using PaymentService.Infrastructure.Repositories.PaymentRepositories;
using PaymentService.Services.MigrationService;
using PaymentService.Services.PaymentServices;
using PaymentService.Services.Profiles;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


builder.Services.AddScoped<IPaymentServices, PaymentsService>();
builder.Services.AddScoped<MigrationService>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

MigrationService.InitializeMigration(app);

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();

