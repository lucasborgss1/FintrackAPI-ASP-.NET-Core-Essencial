using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transacao>> GetTransacoesComRelacionamentosAsync()
    {
        return await _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .ToListAsync();
    }

    public async Task<Transacao?> GetTransacaoComRelacionamentosAsync(long id)
    {
        return await _context.Transacoes
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.TipoTransacao)
            .FirstOrDefaultAsync(t => t.TransacaoId == id);
    }
}