using System.ComponentModel.DataAnnotations;

namespace FintrackAPI.DTOs.TipoTransacao;

/// <summary>
/// Dados necessários para criar ou atualizar um tipo de transação
/// </summary>
public class TipoTransacaoRequestDTO
{
    /// <summary>
    /// Nome do tipo de transação (mínimo 5, máximo 50 caracteres)
    /// </summary>
    /// <example>Despesa</example>
    [Required(ErrorMessage = "O nome do tipo de transação é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
    [MinLength(5, ErrorMessage = "O nome do tipo de transação deve ter, no mínimo, {1} caracteres")]
    public string? Nome { get; set; }

    /// <summary>
    /// Descrição do tipo de transação (máximo 150 caracteres)
    /// </summary>
    /// <example>Saídas de dinheiro e pagamentos</example>
    [StringLength(150, ErrorMessage = "A descrição não pode exceder 150 caracteres")]
    public string? Descricao { get; set; }
}