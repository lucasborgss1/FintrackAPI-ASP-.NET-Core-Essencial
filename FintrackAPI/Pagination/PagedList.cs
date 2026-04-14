using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Pagination;

/// <summary>
/// Lista paginada que encapsula os itens e os metadados de paginação
/// </summary>
/// <typeparam name="T">Tipo dos itens da lista</typeparam>
public class PagedList<T> : List<T> where T : class
{
    /// <summary>Número da página atual</summary>
    public int CurrentPage { get; private set; }

    /// <summary>Total de páginas disponíveis</summary>
    public int TotalPages { get; private set; }

    /// <summary>Quantidade de itens por página</summary>
    public int PageSize { get; private set; }

    /// <summary>Total de registros encontrados</summary>
    public int TotalCount { get; private set; }

    /// <summary>Indica se existe uma página anterior</summary>
    public bool HasPrevious => CurrentPage > 1;

    /// <summary>Indica se existe uma próxima página</summary>
    public bool HasNext => CurrentPage < TotalPages;

    /// <summary>
    /// Inicializa a lista paginada com os itens e metadados
    /// </summary>
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    /// <summary>
    /// Cria uma lista paginada de forma assíncrona a partir de uma query
    /// </summary>
    /// <param name="source">Query IQueryable a ser paginada</param>
    /// <param name="pageNumber">Número da página desejada</param>
    /// <param name="pageSize">Quantidade de itens por página</param>
    public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var itens = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(itens, count, pageNumber, pageSize);
    }
}
