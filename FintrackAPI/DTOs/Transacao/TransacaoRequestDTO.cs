using System.ComponentModel.DataAnnotations;
using FintrackAPI.Validations;

namespace FintrackAPI.DTOs.Transacao;

public class TransacaoRequestDTO
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres")]
    [MinLength(4, ErrorMessage = "O titulo deve ter, no mínimo, {1} caracteres")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório")]
    [ValorMinimoTransacao]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A data é obrigatória")]
    public DateOnly Data { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória")]
    public long CategoriaId { get; set; }

    [Required(ErrorMessage = "O tipo de transação é obrigatório")]
    public long TipoTransacaoId { get; set; }

    [Required(ErrorMessage = "A indicação de crédito é obrigatória")]
    public bool IsCredito { get; set; }

    [Required(ErrorMessage = "A indicação de recorrência é obrigatória")]
    public bool IsRecorrente { get; set; }
}