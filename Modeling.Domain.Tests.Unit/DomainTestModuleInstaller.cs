using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Domain.Tests.Unit.Entities.TestDomain;
using Modeling.Infrastructure;

namespace Modeling.Domain.Tests.Unit;

#pragma warning disable CS8625
public sealed class DomainTestModuleInstaller : IModuleInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<WordListener>()
            .AddScoped<NumberListener>();
    }
}