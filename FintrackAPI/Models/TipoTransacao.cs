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

    [Required(ErrorMessage = "O nome do tipo de transação é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
    [MinLength(5, ErrorMessage = "O nome do tipo de transação deve ter, no mínimo, {1} caracteres")]
    [Column("tpt_nm_nome")]
    public string? Nome { get; set; }

    [StringLength(150, ErrorMessage = "A descrição não pode exceder 150 caracteres")]
    [Column("tpt_ds_descricao")]
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; set; }
}