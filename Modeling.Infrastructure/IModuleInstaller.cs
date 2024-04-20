using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modeling.Infrastructure;

public interface IModuleInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration
    );
}