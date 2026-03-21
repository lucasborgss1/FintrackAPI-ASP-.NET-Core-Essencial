using FintrackAPI.Context;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private ICategoriaRepository? _categoriaRepo;

    private ITipoTransacaoRepository? _tipoTransacaoRepo;

    private ITransacaoRepository? _transacaoRepo;

    public AppDbContext _context = context;


    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
        }
    }

    public ITipoTransacaoRepository TipoTransacaoRepository
    {
        get
        {
            return _tipoTransacaoRepo = _tipoTransacaoRepo ?? new TipoTransacaoRepository(_context);
        }
    }

    public ITransacaoRepository TransacaoRepository
    {
        get
        {
            return _transacaoRepo = _transacaoRepo ?? new TransacaoRepository(_context);
        }
    }



    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
