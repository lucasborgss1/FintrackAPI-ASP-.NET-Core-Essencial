using FintrackAPI.Models;

namespace FintrackAPI.Repositories.Interfaces;

/// <summary>
/// Contrato de operações específicas para o repositório de tipos de transação
/// </summary>
public interface ITipoTransacaoRepository : IRepository<TipoTransacao>
{
    /// <summary>Retorna todos os tipos de transação com suas transações associadas</summary>
    Task<IEnumerable<TipoTransacao>> GetTipoTransacoesComTransacoesAsync();

    /// <summary>Retorna um tipo de transação pelo ID com suas transações associadas</summary>
    /// <param name="id">ID do tipo de transação</param>
    Task<TipoTransacao?> GetTipoTransacaoComTransacoesAsync(long id);
}