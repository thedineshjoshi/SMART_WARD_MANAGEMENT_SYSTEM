using Application.Interfaces;
using Application.UseCases;
using Domain;
using Infrastructure.Logging;
using SMART_WARD_MANAGEMENT_SYSTEM;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<WardApplicationService>();
builder.Services.AddSmartWardManagementSystemDI(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddAuthorization();
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
