using FintrackAPI.Models;
using FintrackAPI.Pagination;
using X.PagedList; // Adicionado o novo namespace

namespace FintrackAPI.Repositories.Interfaces;

/// <summary>
/// Contrato de operações específicas para o repositório de transações
/// </summary>
public interface ITransacaoRepository : IRepository<Transacao>
{
    /// <summary>Retorna todas as transações paginadas com categoria e tipo carregados</summary>
    /// <param name="transacaoParams">Parâmetros de paginação</param>
    Task<IPagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams); // Alterado para IPagedList

    /// <summary>Retorna transações filtradas por data com paginação</summary>
    /// <param name="transacaoFiltroData">Parâmetros de filtro e paginação</param>
    Task<IPagedList<Transacao>> GetTransacoesFiltroDataAsync(TransacaoDataParameters transacaoFiltroData); // Alterado para IPagedList

    /// <summary>Retorna uma transação pelo ID com categoria e tipo carregados</summary>
    /// <param name="id">ID da transação</param>
    Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id);
}