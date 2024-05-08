using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Tests.EfCore.Persistence;

namespace Modeling.Application.Tests.EfCore;

public static class ServiceExtensions
{
    public static IServiceCollection AddTestCore(this IServiceCollection services)
    {
        return services
                .AddNpgsql<AutoShopContext>(connectionString: PostgresDatabaseSharedDependency.ConnectionString!)
                .AddSingleton<AutoShopService>()
            ;
    }
}