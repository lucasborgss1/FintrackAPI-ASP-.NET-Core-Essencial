using System.Text.Json.Serialization;

namespace FintrackAPI.Models;

public class TipoTransacao
{
    public int TipoTransacaoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    [JsonIgnore]
    public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
}
