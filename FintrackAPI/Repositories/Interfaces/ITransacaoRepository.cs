using FintrackAPI.Models;
using FintrackAPI.Pagination;

namespace FintrackAPI.Repositories.Interfaces;

public interface ITransacaoRepository : IRepository<Transacao>
{
    //Task<IEnumerable<Transacao>> GetAllAsync(TransacaoParameters transacaoParams);
    Task<PagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams);
    //Task<IEnumerable<Transacao>> GetTransacoesComRelacionamentosAsync();
    Task<PagedList<Transacao>> GetTransacoesFiltroData(TransacaoDataParameters transacaoFiltroData);
    Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id);
}