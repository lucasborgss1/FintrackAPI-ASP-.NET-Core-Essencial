namespace FintrackAPI.Models;

public class Transacao
{
    public int TransacaoId { get; set; }
    public string? Titulo { get; set; };
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public TipoTransacao? Tipo { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
