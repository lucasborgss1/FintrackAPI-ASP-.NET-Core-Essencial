namespace FintrackAPI.Repositories.Interfaces;

/// <summary>
/// Coordena os repositórios e persiste as alterações no banco em uma única transação
/// </summary>
public interface IUnitOfWork
{
    /// <summary>Repositório de categorias</summary>
    ICategoriaRepository CategoriaRepository { get; }

    /// <summary>Repositório de tipos de transação</summary>
    ITipoTransacaoRepository TipoTransacaoRepository { get; }

    /// <summary>Repositório de transações</summary>
    ITransacaoRepository TransacaoRepository { get; }

    /// <summary>Persiste todas as alterações pendentes no banco de dados</summary>
    Task Commit();
}
