using CloudWeather.Precipitation.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrecipDbContext>(
    options =>
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
        options.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    }, ServiceLifetime.Transient
);

var app = builder.Build();

app.MapGet("/observation/{zip}", async (string zip, [FromQuery] int? days, PrecipDbContext db) =>
{
    if (days == null || days < 1 || days > 30) return Results.BadRequest("Please provide a 'days' query parameter between 1 and 30");

    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var results = await db.Precipitaion.Where(p => p.ZipCode == zip && p.CreatedOn > startDate).ToListAsync();

    return Results.Ok(results);
});

app.Run();
