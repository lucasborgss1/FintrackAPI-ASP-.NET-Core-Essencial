using FintrackAPI.Models;
using FintrackAPI.Pagination;

namespace FintrackAPI.Repositories.Interfaces;

public interface ITransacaoRepository : IRepository<Transacao>
{
    //Task<IEnumerable<Transacao>> GetAllAsync(TransacaoParameters transacaoParams);
    Task<PagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams);
    Task<IEnumerable<Transacao>> GetTransacoesComRelacionamentosAsync();
    Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id);
}