using Microsoft.AspNetCore.Mvc.Filters;

namespace FintrackAPI.Filters;

/// <summary>
/// Filter de log que registra informações de cada request e response processados pelos controllers
/// </summary>
public class ApiLoggingFilter(ILogger<ApiLoggingFilter> logger) : IActionFilter
{
    private readonly ILogger<ApiLoggingFilter> _logger = logger;

    /// <inheritdoc />
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("### Executando -> OnActionExecuting");
        _logger.LogInformation("####################################");
        _logger.LogInformation("{Timestamp}", DateTime.Now.ToLongTimeString());
        _logger.LogInformation("Model State válido: {IsValid}", context.ModelState.IsValid);
        _logger.LogInformation("####################################");
    }

    /// <inheritdoc />
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("### Executando -> OnActionExecuted");
        _logger.LogInformation("####################################");
        _logger.LogInformation("{Timestamp}", DateTime.Now.ToLongTimeString());
        _logger.LogInformation("Status Code: {StatusCode}", context.HttpContext.Response.StatusCode);
        _logger.LogInformation("####################################");
    }
}
