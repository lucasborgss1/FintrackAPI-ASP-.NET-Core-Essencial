using FintrackAPI.Models;

namespace FintrackAPI.Repositories.Interfaces;

/// <summary>
/// Contrato de operações específicas para o repositório de categorias
/// </summary>
public interface ICategoriaRepository : IRepository<Categoria>
{
    /// <summary>Retorna todas as categorias com suas transações associadas</summary>
    Task<IEnumerable<Categoria>> GetCategoriasComTransacoesAsync();

    /// <summary>Retorna uma categoria pelo ID com suas transações associadas</summary>
    /// <param name="id">ID da categoria</param>
    Task<Categoria?> GetCategoriaComTransacoesAsync(long id);
}