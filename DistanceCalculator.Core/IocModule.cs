using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Factories;
using DistanceCalculator.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DistanceCalculator.Core;

public static class IocModule
{
    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        collection.AddScoped<ICalculatorStrategy, CosineLawCalculatorStrategy>();
        collection.AddScoped<ICalculatorStrategy, PythagoraCalculatorStrategy>();
        collection.AddScoped<ICalculatorContext, CalculatorContext>();
        collection.AddScoped<IConverterService, ConverterService>();
        collection.AddScoped<IDistanceService, DistanceService>();

        return collection;
    }
}
