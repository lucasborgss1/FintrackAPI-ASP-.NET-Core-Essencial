namespace FintrackAPI.DTOs.Categoria;

/// <summary>
/// Dados retornados de uma categoria
/// </summary>
public class CategoriaResponseDTO
{
    /// <summary>ID único da categoria</summary>
    /// <example>1000000001</example>
    public long CategoriaId { get; set; }

    /// <summary>Nome da categoria</summary>
    /// <example>Alimentação</example>
    public string? Nome { get; set; }

    /// <summary>Descrição da categoria</summary>
    /// <example>Gastos com alimentação e supermercado</example>
    public string? Descricao { get; set; }
}