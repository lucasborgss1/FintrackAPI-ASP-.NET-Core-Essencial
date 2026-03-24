using System.ComponentModel.DataAnnotations;

namespace FintrackAPI.DTOs.Categoria;

public class CategoriaRequestDTO
{
    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
    [MinLength(5, ErrorMessage = "O nome da categoria deve ter, no mínimo, {1} caracteres")]
    public string? Nome { get; set; }

    [StringLength(150, ErrorMessage = "A descrição não pode exceder 150 caracteres")]
    public string? Descricao { get; set; }
}