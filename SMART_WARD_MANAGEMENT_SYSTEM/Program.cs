using Application.Interfaces;
using Application.UseCases;
using Domain;
using Infrastructure.Logging;
using SMART_WARD_MANAGEMENT_SYSTEM;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Audit mapping
builder.Services.AddScoped<IAuditLogger, SqlAuditLogger>();

// 2. Activity mapping
builder.Services.AddScoped<IActivityLogger, FileActivityLogger>();

// 3. System mapping
builder.Services.AddScoped<ISystemLogger, SerilogSystemLogger>();

builder.Services.AddScoped<WardApplicationService>();

builder.Services.AddSmartWardManagementSystemDI(builder.Configuration);
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
