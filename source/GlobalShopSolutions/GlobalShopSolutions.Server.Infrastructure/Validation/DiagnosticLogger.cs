using Microsoft.Extensions.Logging;
using Modeling.Application.Logging;

namespace GlobalShopSolutions.Server.Infrastructure.Validation;

public sealed class DiagnosticLogger : IDiagnosticLogger
{
    private readonly ILogger _logger;

    public DiagnosticLogger(ILogger<DiagnosticLogger> logger)
    {
        _logger = logger;
    }

    public void Log(string message)
    {
        _logger.LogInformation(message);
    }
    
    public void Log(string message, object arg, params object[] args)
    {
        _logger.LogInformation(message, arg, args);
    }

    public void LogError(Exception ex)
    {
        _logger.LogError("{ExceptionMessage}, {StackTrace}",ex.Message, ex.StackTrace);
    }
}