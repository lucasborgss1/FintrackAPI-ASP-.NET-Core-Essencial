namespace FintrackAPI.Models;

public class Transacao
{
    public int TransacaoId { get; set; }
    public string? Titulo { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public int CategoriaId { get; set; } // Chave estrangeira - Referência ao Id da Categoria.
    public Categoria? Categoria { get; set; }
    public int TipoTransacaoId { get; set; } // Chave estrangeira - Referência ao Id do TipoTransacao.
    public TipoTransacao? TipoTransacao { get; set; }
    public bool IsCredito { get; set; } // Se representa uma transação no crédito.
    public bool IsRecorrente { get; set; } // Se representa uma transação recorrente.
}
