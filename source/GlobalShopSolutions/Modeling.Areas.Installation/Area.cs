using Modeling.Infrastructure;

namespace Modeling.Areas.Installation;

public sealed class Area
{
    public required string Name { get; init; }
    public required IReadOnlyCollection<Module> Modules { get; init; }
}