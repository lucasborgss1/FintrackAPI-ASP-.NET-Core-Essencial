using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

/// <summary>
/// Implementação do repositório de tipos de transação
/// </summary>
public class TipoTransacaoRepository(AppDbContext context) : Repository<TipoTransacao>(context), ITipoTransacaoRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<TipoTransacao>> GetTipoTransacoesComTransacoesAsync()
    {
        return await _context.TipoTransacoes
            .AsNoTracking()
            .Include(t => t.Transacoes)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<TipoTransacao?> GetTipoTransacaoComTransacoesAsync(long id)
    {
        return await _context.TipoTransacoes
            .AsNoTracking()
            .Include(t => t.Transacoes)
            .FirstOrDefaultAsync(t => t.TipoTransacaoId == id);
    }
}