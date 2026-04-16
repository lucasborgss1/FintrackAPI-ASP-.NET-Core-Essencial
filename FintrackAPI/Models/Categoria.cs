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
    public long CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
    [MinLength(5, ErrorMessage = "O nome da categoria deve ter, no mínimo, {1} caracteres")]
    [Column("cat_nm_nome")]
    public string? Nome { get; set; }

    [StringLength(150, ErrorMessage = "A descrição não pode exceder 150 caracteres")]
    [Column("cat_ds_descricao")]
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; set; }
}