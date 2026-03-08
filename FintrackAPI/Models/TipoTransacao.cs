using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace FintrackAPI.Models;

public class TipoTransacao
{
    public TipoTransacao()
    {
        Transacoes = new Collection<Transacao>();
    }
    public int TipoTransacaoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; set; }
}
