using System.Linq.Expressions;
using FintrackAPI.Context;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Repositories;

/// <summary>
/// Implementação base de operações CRUD para qualquer entidade
/// </summary>
public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    protected readonly AppDbContext _context = context;

    /// <inheritdoc />
    public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

    /// <inheritdoc />
    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

    /// <inheritdoc />
    public T Create(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    /// <inheritdoc />
    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    /// <inheritdoc />
    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return entity;
    }
}