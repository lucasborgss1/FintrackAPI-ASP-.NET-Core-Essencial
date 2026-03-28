using System.Linq;
using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Pagination;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

public class TransacaoRepository(AppDbContext context) : Repository<Transacao>(context), ITransacaoRepository
{
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

    public async Task<IEnumerable<Transacao>> GetAllAsync(TransacaoParameters transacaoParams)
    {
        return await _context.Transacoes
            .OrderBy(t => t.Titulo)
            .Skip((transacaoParams.PageNumber - 1) * transacaoParams.PageSize)
            .Take(transacaoParams.PageSize).ToListAsync();
    }
}