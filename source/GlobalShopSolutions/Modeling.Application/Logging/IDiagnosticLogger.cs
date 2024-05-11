namespace Modeling.Application.Logging;

/// <summary>
/// A logger for debugging
/// and development information
/// </summary>
public interface IDiagnosticLogger
{
    /// <summary>
    /// Log the information
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message);

    /// <summary>
    /// Log the information
    /// </summary>
    /// <param name="message"></param>
    /// <param name="arg"></param>
    /// <param name="args"></param>
    public void Log(string message, object arg, params object[] args);

    /// <summary>
    /// Log an error
    /// </summary>
    /// <param name="ex"></param>
    public void LogError(Exception ex);
}

/// <summary>
/// A logger for enhancing business
/// understanding. E.g. for service
/// personnel
/// </summary>
public interface IServiceLogger
{
    /// <summary>
    /// Log the information
    /// </summary>
    /// <param name="info"></param>
    public void Log(string info);
}