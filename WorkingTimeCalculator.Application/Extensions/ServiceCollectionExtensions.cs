using Microsoft.Extensions.DependencyInjection;
using WorkingDayCalculator.Application.Services;
using WorkingDayCalculator.Application.Services.Interfaces;
using WorkingDayCalculator.Infrastructure.Extensions;

namespace WorkingDayCalculator.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .ConfigureServices()
            .ConfigureInfrastructure();
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IDayCalculatorService, DayCalculatorService>();
    }
}

