using System.Linq.Expressions;

namespace FintrackAPI.Repositories.Interfaces;

/// <summary>
/// Contrato base de operações CRUD para qualquer entidade
/// </summary>
/// <typeparam name="T">Tipo da entidade</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>Retorna todos os registros da entidade</summary>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>Retorna o primeiro registro que satisfaz o predicado informado</summary>
    /// <param name="predicate">Expressão de filtro</param>
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>Adiciona um novo registro ao contexto</summary>
    /// <param name="entity">Entidade a ser criada</param>
    T Create(T entity);

    /// <summary>Atualiza um registro existente no contexto</summary>
    /// <param name="entity">Entidade com os dados atualizados</param>
    T Update(T entity);

    /// <summary>Remove um registro do contexto</summary>
    /// <param name="entity">Entidade a ser removida</param>
    T Delete(T entity);
}