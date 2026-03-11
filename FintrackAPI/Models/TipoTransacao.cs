using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FintrackAPI.Models;

[Table("TPT_tipo_transacao")]
public class TipoTransacao
{
    public TipoTransacao()
    {
        Transacoes = new Collection<Transacao>();
    }

    [Key]
    [Column("tpt_id_tipo_transacao")]
    public long TipoTransacaoId { get; set; }

    [Required]
    [StringLength(50)]
    [Column("tpt_nm_nome")]
    public string? Nome { get; set; }

    [StringLength(150)]
    [Column("tpt_ds_descricao")]
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; set; }
}