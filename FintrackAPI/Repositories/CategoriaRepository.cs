using FintrackAPI.Context;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

public class CategoriaRepository(AppDbContext context) : Repository<Categoria>(context), ICategoriaRepository
{
    public async Task<IEnumerable<Categoria>> GetCategoriasComTransacoesAsync()
    {
        return await _context.Categorias
            .AsNoTracking()
            .Include(c => c.Transacoes)
            .ToListAsync();
    }

    public async Task<Categoria?> GetCategoriaComTransacoesAsync(long id)
    {
        return await _context.Categorias
            .AsNoTracking()
            .Include(c => c.Transacoes)
            .FirstOrDefaultAsync(c => c.CategoriaId == id);
    }
}