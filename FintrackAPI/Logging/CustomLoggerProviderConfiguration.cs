namespace FintrackAPI.Logging;

/// <summary>
/// Configuração do provider de log customizado
/// </summary>
public class CustomLoggerProviderConfiguration
{
    /// <summary>Nível mínimo de log a ser registrado</summary>
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;

    /// <summary>ID do evento de log (0 = todos)</summary>
    public int EventId { get; set; } = 0;
}
