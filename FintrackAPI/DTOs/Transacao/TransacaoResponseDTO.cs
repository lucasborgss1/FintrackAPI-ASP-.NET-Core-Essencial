namespace FintrackAPI.DTOs.Transacao;

public class TransacaoResponseDTO
{
    public long TransacaoId { get; set; }
    public string? Titulo { get; set; }
    public decimal Valor { get; set; }
    public DateOnly Data { get; set; }
    public long CategoriaId { get; set; }
    public string? CategoriaNome { get; set; }
    public long TipoTransacaoId { get; set; }
    public string? TipoTransacaoNome { get; set; }
    public bool IsCredito { get; set; }
    public bool IsRecorrente { get; set; }
}