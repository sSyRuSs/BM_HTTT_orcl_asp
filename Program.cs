using AutoMapper;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.OpenApi.Models;
using ExceptionHandling.Middlewares;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<ModelContext>(option =>
    option.UseOracle(builder.Configuration.GetConnectionString("MyDB")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IDongspRepository, DongspRepository>();
builder.Services.AddScoped<ISanphamRepository, SanphamRepository>();
builder.Services.AddScoped<INhanvienRepository, NhanvienRepository>();
builder.Services.AddScoped<ITaikhoannvRepository, TaikhoannvRepository>();
builder.Services.AddScoped<IKhachangRepository, Khachhangrepository>();
builder.Services.AddScoped<IHoadonRepository, HoadonRepository>();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
