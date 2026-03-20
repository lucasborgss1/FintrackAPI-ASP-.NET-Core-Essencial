using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

public class TipoTransacaoRepository : Repository<TipoTransacao>, ITipoTransacaoRepository
{
    public TipoTransacaoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TipoTransacao>> GetTipoTransacoesComTransacoesAsync()
    {
        return await _context.TipoTransacoes
            .AsNoTracking()
            .Include(t => t.Transacoes)
            .ToListAsync();
    }

    public async Task<TipoTransacao?> GetTipoTransacaoComTransacoesAsync(long id)
    {
        return await _context.TipoTransacoes
            .AsNoTracking()
            .Include(t => t.Transacoes)
            .FirstOrDefaultAsync(t => t.TipoTransacaoId == id);
    }
}