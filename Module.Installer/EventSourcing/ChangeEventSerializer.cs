using Modeling.Domain.EventSourcing;
using Newtonsoft.Json;

namespace Module.Installer.EventSourcing;

/// <summary>
/// Serialization for streaming change events
/// </summary>
internal sealed class ChangeEventSerializer
{
    /// <summary>
    /// Serialize events into storable payloads
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public string Serialize(IChangeEvent e)
    {
        return JsonConvert.SerializeObject(e);
    }

}