using System.Reflection;
using Modeling.Application.Cqrs.EventSourcing.Events;
using Modeling.Domain.EventSourcing;
using Serilog;

namespace GlobalShopSolutions.Server.Infrastructure.EventSourcing;

/// <summary>
/// This is critical infrastructure supporting type serialization.
/// <br/>
/// When events are written to logs this is used to read the
/// events back into their runtime types
/// </summary>
internal sealed class ChangeEventTypeMap
{
    private readonly ILogger _logger;
    private readonly Dictionary<EventType, Type> _map = new();
    private readonly Dictionary<Type, EventType> _coMap = new();

    public ChangeEventTypeMap(List<Assembly> serviceAssemblies, ILogger logger)
    {
        _logger = logger;
        
        serviceAssemblies
            .SelectMany(a => a.GetTypes())
            .Where(type => typeof(IChangeEvent).IsAssignableFrom(type))
            .ToList()
            .ForEach(Add)
            ;
    }

    private void Add(Type t)
    {
        EventType et = t;
        _logger.Information("Mapping {Type} to {EventType}", t.Name, nameof(et));
        
        _map.Add(et, t);
        _coMap.Add(t, et);
    }
    
    public Type Map(EventType eventType)
    {
        return _map[eventType];
    }

    public EventType Map(Type type)
    {
        return _coMap[type];
    }
}