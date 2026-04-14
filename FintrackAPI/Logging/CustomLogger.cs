namespace FintrackAPI.Logging;

/// <summary>
/// Logger customizado que persiste mensagens em arquivo de texto.
/// O caminho do arquivo é lido da configuração <c>Logging:FilePath</c>.
/// </summary>
public class CustomLogger(CustomLoggerProviderConfiguration loggerConfig) : ILogger
{
    private static readonly string _defaultPath = Path.Combine(AppContext.BaseDirectory, "logs", "fintrack_log.txt");

    /// <inheritdoc />
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel) => logLevel == loggerConfig.LogLevel;

    /// <inheritdoc />
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var mensagem = $"{logLevel} : {eventId} = {formatter(state, exception)}";
        EscreveTextoNoArquivo(mensagem);
    }

    private static void EscreveTextoNoArquivo(string mensagem)
    {
        var diretorio = Path.GetDirectoryName(_defaultPath)!;
        Directory.CreateDirectory(diretorio);

        using var streamWriter = new StreamWriter(_defaultPath, append: true);
        streamWriter.WriteLine(mensagem);
    }
}