using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Tests.Unit.Queries.TestApplication;
using Modeling.Infrastructure;

namespace Modeling.Application.Tests.Unit;

public sealed class ApplicationTestModuleInstaller : IModuleInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ThingStore>();
    }
}