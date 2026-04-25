using ValidIpandBlockCountires.Infrastructure.Config;
using ValidIpandBlockCountires.Service.Config;
using ValidIpandBlockCountires.Service.Services;
using ValidIPandBlockedCountries.API;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// bind GeoApiSettings from appsettings.json
builder.Services.AddGeoApiSettings(builder.Configuration);
// Add infrastructure and service dependencies Injection
builder.Services.AddInfrastructureDependencies();
builder.Services.AddServiceDependencies();

builder.Services.AddHttpClient<IIpGeolocationService, IpGeolocationService>();

// Background service to clean up expired blocked countries every 5 minutes
builder.Services.AddHostedService<TempBlockedCountriesCleanupService>();

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
