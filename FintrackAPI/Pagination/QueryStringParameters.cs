namespace FintrackAPI.Pagination;

/// <summary>
/// Parâmetros base de paginação herdados por todos os filtros
/// </summary>
public abstract class QueryStringParameters
{
    private const int MaxPageSize = 10;

    /// <summary>
    /// Número da página atual (padrão: 1)
    /// </summary>
    /// <example>1</example>
    public int PageNumber { get; set; } = 1;

    private int _pageSize = MaxPageSize;

    /// <summary>
    /// Quantidade de itens por página (padrão: 10)
    /// </summary>
    /// <example>10</example>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
