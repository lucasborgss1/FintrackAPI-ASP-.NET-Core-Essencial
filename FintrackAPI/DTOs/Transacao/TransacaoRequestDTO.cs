using System.ComponentModel.DataAnnotations;
using FintrackAPI.Validations;

namespace FintrackAPI.DTOs.Transacao;

/// <summary>
/// Dados necessários para criar ou atualizar uma transação
/// </summary>
public class TransacaoRequestDTO
{
    /// <summary>
    /// Título da transação (mínimo 4, máximo 100 caracteres)
    /// </summary>
    /// <example>Compra no Supermercado</example>
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres")]
    [MinLength(4, ErrorMessage = "O titulo deve ter, no mínimo, {1} caracteres")]
    public string? Titulo { get; set; }

    /// <summary>
    /// Valor da transação (deve ser maior que 0)
    /// </summary>
    /// <example>350.75</example>
    [Required(ErrorMessage = "O valor é obrigatório")]
    [ValorMinimoTransacao]
    public decimal Valor { get; set; }

    /// <summary>
    /// Data em que a transação ocorreu (formato: yyyy-MM-dd)
    /// </summary>
    /// <example>2026-03-05</example>
    [Required(ErrorMessage = "A data é obrigatória")]
    public DateOnly Data { get; set; }

    /// <summary>
    /// ID da categoria associada à transação (opcional)
    /// </summary>
    /// <example>1000000001</example>
    public long? CategoriaId { get; set; }

    /// <summary>
    /// ID do tipo de transação (Despesa, Receita, Transferência)
    /// </summary>
    /// <example>1000000001</example>
    [Required(ErrorMessage = "O tipo de transação é obrigatório")]
    public long TipoTransacaoId { get; set; }

    /// <summary>
    /// Indica se a transação é do tipo crédito
    /// </summary>
    /// <example>true</example>
    [Required(ErrorMessage = "A indicação de crédito é obrigatória")]
    public bool IsCredito { get; set; }

    /// <summary>
    /// Indica se a transação é recorrente
    /// </summary>
    /// <example>false</example>
    [Required(ErrorMessage = "A indicação de recorrência é obrigatória")]
    public bool IsRecorrente { get; set; }
}