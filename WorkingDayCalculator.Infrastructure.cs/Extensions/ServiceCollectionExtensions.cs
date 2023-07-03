using Microsoft.Extensions.DependencyInjection;
using WorkingDayCalculator.Application.Services;
using WorkingDayCalculator.Infrastructure.Services.Interfaces;

namespace WorkingDayCalculator.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection serviceCollection)
    {
        return ConfigureServices(serviceCollection);
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<ILogonAuditService, LogonAuditService>();
    }
}
