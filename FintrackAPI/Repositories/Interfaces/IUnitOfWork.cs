namespace FintrackAPI.Repositories.Interfaces;

public interface IUnitOfWork
{
    ICategoriaRepository CategoriaRepository { get; }
    ITipoTransacaoRepository TipoTransacaoRepository { get; }
    ITransacaoRepository TransacaoRepository { get; }
    Task Commit();
}
