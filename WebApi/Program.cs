using ApplicationLayer.Interface;
using Data.AppDbContext;
using InfrastructureLayer.Implementation;
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DBcon")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployee, EmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(policy =>
    {
        policy.WithOrigins("https://localhost:7144")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithHeaders(HeaderNames.ContentType);
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
