using CKO.BankSimulator.Repository;
using Microsoft.EntityFrameworkCore;
using CKO.BankSimulator.DataContext;
using CKO.PaymentGateway.API.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;
using CKO.PaymentGateway.Contracts.MerchantAuthentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using CKO.PaymentGateway.MerchantAuthentication;

var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSwaggerGen(options =>
    {

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT Token",
            Type = SecuritySchemeType.Http
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
    });

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
    builder.Services.AddAuthorization();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PaymentDBContext>(options => options.UseInMemoryDatabase("PaymentDB"));
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddScoped<IMerchantAuthenticationService, MerchantAuthenticationService>();

builder.Services.AddScoped<IPaymentProcessingRepository, PaymentProcessingRepository>();
builder.Services.AddScoped<IPaymentProcessingService, SimulatorPaymentProcessingService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login",
    (MerchantLogin merchant, IMerchantAuthenticationService service) => Login(merchant, service));

IResult Login(MerchantLogin merchant, IMerchantAuthenticationService service)
{
    if (!string.IsNullOrEmpty(merchant.MerchantId) &&
            !string.IsNullOrEmpty(merchant.Secret))
    {
        var loggedInUser = service.Get(merchant);
        if (loggedInUser is null) return Results.NotFound("Merchant not found");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, loggedInUser.MerchantId)
        };

        var token = new JwtSecurityToken
        (
            issuer: builder.Configuration["Jwt:Issuer"],
            audience: builder.Configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(tokenString);
    }
    return Results.BadRequest("Invalid merchant credentials");
}

app.MapControllers();
app.UseSwaggerUI();

app.Run();
