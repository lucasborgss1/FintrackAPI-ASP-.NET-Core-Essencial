using System.Text.Json.Serialization;
using FintrackAPI.Context;
using FintrackAPI.Extensions;
using FintrackAPI.Filters;
using FintrackAPI.Logging;
using FintrackAPI.Repositories;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
})
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<ApiLoggingFilter>();
builder.Logging.AddProvider(new CustomLoggerProvider(
    new CustomLoggerProviderConfiguration { LogLevel = LogLevel.Information }));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<AppDbContext>(options =>
        options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITipoTransacaoRepository, TipoTransacaoRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
