namespace FintrackAPI.DTOs.TipoTransacao;

/// <summary>
/// Dados retornados de um tipo de transação
/// </summary>
public class TipoTransacaoResponseDTO
{
    /// <summary>ID único do tipo de transação</summary>
    /// <example>1000000001</example>
    public long TipoTransacaoId { get; set; }

    /// <summary>Nome do tipo de transação</summary>
    /// <example>Despesa</example>
    public string? Nome { get; set; }

    /// <summary>Descrição do tipo de transação</summary>
    /// <example>Saídas de dinheiro e pagamentos</example>
    public string? Descricao { get; set; }
}