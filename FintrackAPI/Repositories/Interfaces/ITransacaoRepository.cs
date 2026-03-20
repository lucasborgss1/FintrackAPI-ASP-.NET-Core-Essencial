using FintrackAPI.Models;

namespace FintrackAPI.Repositories.Interfaces;

public interface ITransacaoRepository : IRepository<Transacao>
{
    Task<IEnumerable<Transacao>> GetTransacoesComRelacionamentosAsync();
    Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id);
}