using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FintrackAPI.Models;

[Table("TRA_transacao")]
public class Transacao
{
    [Key]
    [Column("tra_id_transacao")]
    public int TransacaoId { get; set; }

    [Required]
    [StringLength(100)]
    [Column("tra_nm_titulo")]
    public string? Titulo { get; set; }

    [Required]
    [Column("tra_vl_valor", TypeName = "decimal(18,2)")]
    public decimal Valor { get; set; }

    [Required]
    [Column("tra_dt_data")]  
    public DateOnly Data { get; set; }

    [Required]
    [Column("tra_id_categoria")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Categoria? Categoria { get; set; }

    [Required]
    [Column("tra_id_tipo_transacao")]
    public int TipoTransacaoId { get; set; }

    [ForeignKey("TipoTransacaoId")]
    public TipoTransacao? TipoTransacao { get; set; }

    [Required]
    [Column("tra_fl_credito")]
    public bool IsCredito { get; set; }

    [Required]
    [Column("tra_fl_recorrente")]
    public bool IsRecorrente { get; set; }
}