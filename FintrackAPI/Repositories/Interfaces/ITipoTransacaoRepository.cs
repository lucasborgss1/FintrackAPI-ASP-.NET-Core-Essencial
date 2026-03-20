using FintrackAPI.Models;

namespace FintrackAPI.Repositories.Interfaces;

public interface ITipoTransacaoRepository : IRepository<TipoTransacao>
{
    Task<IEnumerable<TipoTransacao>> GetTipoTransacoesComTransacoesAsync();
    Task<TipoTransacao?> GetTipoTransacaoComTransacoesAsync(long id);
}