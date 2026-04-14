using System.ComponentModel.DataAnnotations;

namespace FintrackAPI.DTOs.Categoria;

/// <summary>
/// Dados necessários para criar ou atualizar uma categoria
/// </summary>
public class CategoriaRequestDTO
{
    /// <summary>
    /// Nome da categoria (mínimo 5, máximo 50 caracteres)
    /// </summary>
    /// <example>Alimentação</example>
    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
    [MinLength(5, ErrorMessage = "O nome da categoria deve ter, no mínimo, {1} caracteres")]
    public string? Nome { get; set; }

    /// <summary>
    /// Descrição da categoria (máximo 150 caracteres)
    /// </summary>
    /// <example>Gastos com alimentação e supermercado</example>
    [StringLength(150, ErrorMessage = "A descrição não pode exceder 150 caracteres")]
    public string? Descricao { get; set; }
}