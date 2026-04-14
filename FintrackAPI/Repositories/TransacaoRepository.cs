using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Pagination;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

public class TransacaoRepository(AppDbContext context) : Repository<Transacao>(context), ITransacaoRepository
{
    /*
    Método comentado pois não está sendo utilizado. (Substituido por GetAllAsynca paginado)
    
    public async Task<IEnumerable<Transacao>> GetTransacoesComRelacionamentosAsync()
    {
        return await _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .ToListAsync();
    }
   */

    /// <inheritdoc />
    public async Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id)
    {
        return await _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .FirstOrDefaultAsync(t => t.TransacaoId == id);
    }

    /// <inheritdoc />
    public async Task<PagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams)
    {
        var transacoes = _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .OrderBy(t => t.Data);

        return await PagedList<Transacao>.ToPagedListAsync(transacoes, transacaoParams.PageNumber, transacaoParams.PageSize);
    }

    /// <inheritdoc />
    public async Task<PagedList<Transacao>> GetTransacoesFiltroData(TransacaoDataParameters transacaoFiltroData)
    {
        var transacoes = _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .OrderBy(t => t.Data)
            .AsQueryable();

        if (transacaoFiltroData.Data.HasValue)
        {
            var dataFiltro = transacaoFiltroData.Data.Value;

            transacoes = transacaoFiltroData.DataCriterio switch
            {
                DataCriterio.AntesDe => transacoes.Where(t => t.Data < dataFiltro),
                DataCriterio.DepoisDe => transacoes.Where(t => t.Data > dataFiltro),
                DataCriterio.IgualA => transacoes.Where(t => t.Data == dataFiltro),
                _ => transacoes
            };
        }

        return await PagedList<Transacao>.ToPagedListAsync(transacoes, transacaoFiltroData.PageNumber, transacaoFiltroData.PageSize);
    }
}