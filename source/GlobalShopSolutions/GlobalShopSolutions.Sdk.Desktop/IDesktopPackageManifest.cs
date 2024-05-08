using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalShopSolutions.Sdk.Desktop;

public interface IDesktopModule
{
    
}

public interface IDesktopPackageManifest
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration
    );
    
}