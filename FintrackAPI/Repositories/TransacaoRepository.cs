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


    public async Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id)
    {
        return await _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .FirstOrDefaultAsync(t => t.TransacaoId == id);
    }


    public async Task<PagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams)
    {
        var transacoes = _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .OrderBy(t => t.Data);

        return await PagedList<Transacao>.ToPagedListAsync(transacoes, transacaoParams.PageNumber, transacaoParams.PageSize);
    }

    public async Task<PagedList<Transacao>> GetTransacoesFiltroData(TransacaoDataParameters transacaoFiltroData)
    {
        var trasacoes =  _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .OrderBy(t => t.Data)
            .AsQueryable();

        if (transacaoFiltroData.Data.HasValue)
        {
            var dataFiltro = transacaoFiltroData.Data.Value;

            trasacoes = transacaoFiltroData.DataCriterio switch
            {
                DataCriterio.AntesDe  => trasacoes.Where(t => t.Data < dataFiltro),
                DataCriterio.DepoisDe => trasacoes.Where(t => t.Data > dataFiltro),
                DataCriterio.IgualA   => trasacoes.Where(t => t.Data == dataFiltro),
                _                     => trasacoes
            };
        }

        return await PagedList<Transacao>.ToPagedListAsync(trasacoes, transacaoFiltroData.PageNumber, transacaoFiltroData.PageSize);
    }
}