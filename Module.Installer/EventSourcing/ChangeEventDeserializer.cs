using Modeling.Domain.EventSourcing;
using Newtonsoft.Json;

namespace Module.Installer.EventSourcing;

internal sealed class ChangeEventDeserializer
{
    /// <summary>
    /// Deserialize an event from a stored payload
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="serializedEvent"></param>
    /// <returns></returns>
    public ChangeEvent Deserialize(Type eventType, string serializedEvent)
    {
        var deserializedEvent = JsonConvert.DeserializeObject(serializedEvent, eventType)!;
        
        return (ChangeEvent)deserializedEvent;
    }   
}