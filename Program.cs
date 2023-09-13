using AutoMapper;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using ExceptionHandling.Middlewares;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ModelContext>(option =>
    option.UseOracle(builder.Configuration.GetConnectionString("MyDB"))); 

builder.Services.AddScoped<IDongspRepository, DongspRepository>();
builder.Services.AddScoped<ISanphamRepository, SanphamRepository>();
builder.Services.AddScoped<INhanvienRepository, NhanvienRepository>();
builder.Services.AddScoped<ITaikhoannvRepository,TaikhoannvRepository>();
builder.Services.AddScoped<IKhachangRepository,Khachhangrepository>();
builder.Services.AddScoped<IHoadonRepository, HoadonRepository>();

builder.Services.AddAuthentication();
//var serect

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
