using FintrackAPI.Models;
using FintrackAPI.Pagination;

namespace FintrackAPI.Repositories.Interfaces;

/// <summary>
/// Contrato de operações específicas para o repositório de transações
/// </summary>
public interface ITransacaoRepository : IRepository<Transacao>
{
    /// <summary>Retorna todas as transações paginadas com categoria e tipo carregados</summary>
    /// <param name="transacaoParams">Parâmetros de paginação</param>
    Task<PagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams);

    /// <summary>Retorna transações filtradas por data com paginação</summary>
    /// <param name="transacaoFiltroData">Parâmetros de filtro e paginação</param>
    Task<PagedList<Transacao>> GetTransacoesFiltroDataAsync(TransacaoDataParameters transacaoFiltroData);

    /// <summary>Retorna uma transação pelo ID com categoria e tipo carregados</summary>
    /// <param name="id">ID da transação</param>
    Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id);
}