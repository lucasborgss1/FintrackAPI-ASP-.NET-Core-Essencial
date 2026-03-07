using System.Text.Json.Serialization;

namespace FintrackAPI.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string? Nome { get; set; } 
    public string? Descricao { get; set; }

    [JsonIgnore]
    public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
}
