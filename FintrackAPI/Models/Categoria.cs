using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace FintrackAPI.Models;

public class Categoria
{
    public Categoria()
    {
        Transacoes = new Collection<Transacao>();
    }
    public int CategoriaId { get; set; }
    public string? Nome { get; set; } 
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; set; }
}
