using FintrackAPI.Context;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Repositories;

/// <summary>
/// Implementação do Unit of Work — coordena os repositórios e persiste as alterações em uma única transação
/// </summary>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    private ICategoriaRepository? _categoriaRepo;
    private ITipoTransacaoRepository? _tipoTransacaoRepo;
    private ITransacaoRepository? _transacaoRepo;

    /// <inheritdoc />
    public ICategoriaRepository CategoriaRepository
        => _categoriaRepo ??= new CategoriaRepository(_context);

    /// <inheritdoc />
    public ITipoTransacaoRepository TipoTransacaoRepository
        => _tipoTransacaoRepo ??= new TipoTransacaoRepository(_context);

    /// <inheritdoc />
    public ITransacaoRepository TransacaoRepository
        => _transacaoRepo ??= new TransacaoRepository(_context);

    /// <inheritdoc />
    public async Task Commit()
        => await _context.SaveChangesAsync();

    /// <inheritdoc />
    public void Dispose()
        => _context.Dispose();
}
