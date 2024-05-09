using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Modeling.Infrastructure;

public sealed class Module
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required IServiceCollection Services { get; init; }
    public required IReadOnlyCollection<Assembly> ServiceAssemblies { get; init; }
    public required IReadOnlyCollection<Assembly> EndpointAssemblies { get; init; }
}