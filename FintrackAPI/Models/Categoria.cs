using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FintrackAPI.Models;

[Table("CAT_categoria")]
public class Categoria
{
    public Categoria()
    {
        Transacoes = new Collection<Transacao>();
    }

    [Key]
    [Column("cat_id_categoria")]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(50)]
    [Column("cat_nm_nome")]
    public string? Nome { get; set; }

    [StringLength(150)]
    [Column("cat_ds_descricao")]
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; set; }
}