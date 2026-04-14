namespace FintrackAPI.DTOs.Transacao;

/// <summary>
/// Dados retornados de uma transação
/// </summary>
public class TransacaoResponseDTO
{
    /// <summary>ID único da transação</summary>
    /// <example>1000000001</example>
    public long TransacaoId { get; set; }

    /// <summary>Título da transação</summary>
    /// <example>Compra no Supermercado</example>
    public string? Titulo { get; set; }

    /// <summary>Valor da transação</summary>
    /// <example>350.75</example>
    public decimal Valor { get; set; }

    /// <summary>Data em que a transação ocorreu</summary>
    /// <example>2026-03-05</example>
    public DateOnly Data { get; set; }

    /// <summary>Nome da categoria associada</summary>
    /// <example>Alimentação</example>
    public string? CategoriaNome { get; set; }

    /// <summary>Nome do tipo de transação</summary>
    /// <example>Despesa</example>
    public string? TipoTransacaoNome { get; set; }

    /// <summary>Indica se a transação é do tipo crédito</summary>
    /// <example>true</example>
    public bool IsCredito { get; set; }

    /// <summary>Indica se a transação é recorrente</summary>
    /// <example>false</example>
    public bool IsRecorrente { get; set; }
}