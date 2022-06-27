using CKO.BankSimulator.Repository;
using Microsoft.EntityFrameworkCore;
using CKO.BankSimulator.DataContext;
using Microsoft.AspNetCore.Builder;
using CKO.PaymentGateway.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(options =>
{
    
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PaymentDBContext>(options => options.UseInMemoryDatabase("PaymentDB"));
builder.Services.AddEndpointsApiExplorer();



//builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

builder.Services.AddScoped<IPaymentProcessingRepository, PaymentProcessingRepository>();
builder.Services.AddScoped<IPaymentProcessingService, SimulatorPaymentProcessingService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();


app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
