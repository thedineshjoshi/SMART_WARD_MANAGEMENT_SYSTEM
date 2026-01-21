using Application;
using Domain;
using Infrastructure;
using SMART_WARD_MANAGEMENT_SYSTEM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSmartWardManagementSystemDI();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
