using System.Net;
using FintrackAPI.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace FintrackAPI.Extensions;

/// <summary>
/// Extensão para configurar o middleware de tratamento global de exceções no pipeline HTTP.
/// Atua como última linha de defesa para erros que escapam dos controllers.
/// </summary>
public static class ApiExceptionMiddlewareExtentions
{
    /// <summary>
    /// Registra o middleware de exceção que captura erros não tratados no pipeline
    /// e retorna uma resposta JSON padronizada com status 500
    /// </summary>
    /// <param name="app">Instância do pipeline de aplicação</param>
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    }.ToString());
                }
            });
        });
    }
}
