using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Pagination;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
    public async Task<IPagedList<Transacao>> GetAllAsync(TransacaoParameters transacaoParams)
    {
        var transacoes = _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .OrderBy(t => t.Data);

        return await transacoes.ToPagedListAsync(transacaoParams.PageNumber, transacaoParams.PageSize);
    }

    /// <inheritdoc />
    public async Task<IPagedList<Transacao>> GetTransacoesFiltroDataAsync(TransacaoDataParameters transacaoFiltroData)
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
                "AntesDe" => transacoes.Where(t => t.Data < dataFiltro),
                "DepoisDe" => transacoes.Where(t => t.Data > dataFiltro),
                "IgualA" => transacoes.Where(t => t.Data == dataFiltro),
                _ => transacoes
            };
        }

        return await transacoes.ToPagedListAsync(transacaoFiltroData.PageNumber, transacaoFiltroData.PageSize);
    }
}