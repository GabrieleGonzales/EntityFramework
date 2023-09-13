using EntityFrameworkCoreExample.Models;
using EntityFrameworkCoreExample.Interfaces.Repository;
using EntityFrameworkCoreExample.Repository;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreExample.Interfaces.Data;
using EntityFrameworkCoreExample.Data;
using EntityFrameworkCoreExample.Interfaces.Services;
using EntityFrameworkCoreExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
