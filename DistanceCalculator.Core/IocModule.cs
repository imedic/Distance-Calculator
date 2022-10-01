using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DistanceCalculator.Core;

public static class IocModule
{
    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        collection.AddScoped<IDistanceService, DistanceService>();

        return collection;
    }
}
