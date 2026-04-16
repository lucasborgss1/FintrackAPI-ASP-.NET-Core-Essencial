using System.Collections.Concurrent;

namespace FintrackAPI.Logging;

/// <summary>
/// Provider de log customizado que cria instâncias de <see cref="CustomLogger"/> por categoria
/// </summary>
public class CustomLoggerProvider(CustomLoggerProviderConfiguration config) : ILoggerProvider
{
    private readonly CustomLoggerProviderConfiguration _loggerConfig = config;
    private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new();

    /// <inheritdoc />
    public ILogger CreateLogger(string categoryName)
        => _loggers.GetOrAdd(categoryName, name => new CustomLogger(_loggerConfig));

    /// <inheritdoc />
    public void Dispose()
    {
        _loggers.Clear();
    }
}
