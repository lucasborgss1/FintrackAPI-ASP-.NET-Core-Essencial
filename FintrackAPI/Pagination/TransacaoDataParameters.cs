using FintrackAPI.Models;

namespace FintrackAPI.Pagination;

/// <summary>
/// Parâmetros de filtro por data e paginação para busca de transações
/// </summary>
public class TransacaoDataParameters : QueryStringParameters
{
    /// <summary>
    /// Data de referência para o filtro (formato: yyyy-MM-dd)
    /// </summary>
    /// <example>2026-03-05</example>
    public DateOnly? Data { get; set; }

    /// <summary>
    /// Critério de comparação da data: AntesDe, DepoisDe ou IgualA
    /// </summary>
    /// <example>DepoisDe</example>
    public string? DataCriterio { get; set; }
}
