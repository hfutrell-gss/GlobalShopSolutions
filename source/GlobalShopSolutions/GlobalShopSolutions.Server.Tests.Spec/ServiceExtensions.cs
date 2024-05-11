using GlobalShopSolutions.Server.Tests.Spec.Drivers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalShopSolutions.Server.Tests.Spec;

public static class ServiceExtensions
{
    public static IServiceCollection AddWebServer<T>(this IServiceCollection collection) where T : class
    {
        return collection
                .AddSingleton(provider => new WebApplicationFactory<T>()
                    .WithWebHostBuilder(builder => builder.ConfigureServices(services =>
                    {
                        // Ignore self-referential services
                        foreach (var serviceDescriptor in collection.Where(service => 
                                     service.ServiceType != typeof(WebApplicationFactory<T>) 
                                     && service.ServiceType  != typeof(HttpClient)
                                     && service.ServiceType  != typeof(ServerFixtureClient))
                                 )
                        {
                            var serviceInstance = provider.GetService(serviceDescriptor.ServiceType)!;

                            // Check the lifetime of the service and add it accordingly
                            switch (serviceDescriptor.Lifetime)
                            {
                                case ServiceLifetime.Singleton:
                                    services.AddSingleton(serviceDescriptor.ServiceType, serviceInstance);
                                    break;
                                case ServiceLifetime.Scoped:
                                    services.AddScoped(serviceDescriptor.ServiceType, _ => serviceInstance);
                                    break;
                                case ServiceLifetime.Transient:
                                    services.AddTransient(serviceDescriptor.ServiceType, _ => serviceInstance);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                    }))
                )
                .AddSingleton<HttpClient>(p => p.GetService<WebApplicationFactory<T>>()!.CreateClient()!)
            ;
    }
                        
}