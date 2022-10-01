using DistanceCalculator.API.Filters;
using DistanceCalculator.Core;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Host.UseSerilog((builderContext, config) => config.WriteTo.Console().ReadFrom.Configuration(builderContext.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.RegisterServices();

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

app.UseCors(x =>
    x.AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.Run();

public partial class Program { }