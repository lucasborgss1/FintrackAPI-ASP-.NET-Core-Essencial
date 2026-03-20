using FintrackAPI.Models;

namespace FintrackAPI.Repositories.Interfaces;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<IEnumerable<Categoria>> GetCategoriasComTransacoesAsync();
    Task<Categoria?> GetCategoriaComTransacoesAsync(long id);
}