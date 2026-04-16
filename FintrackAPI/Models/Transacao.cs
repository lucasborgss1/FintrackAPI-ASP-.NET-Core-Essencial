using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FintrackAPI.Validations;

namespace FintrackAPI.Models;

[Table("TRA_transacao")]
public class Transacao
{
    [Key]
    [Column("tra_id_transacao")]
    public long TransacaoId { get; set; }

    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres")]
    [MinLength(4, ErrorMessage = "O titulo deve ter, no mínimo, {1} caracteres")]
    [Column("tra_nm_titulo")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório")]
    [ValorMinimoTransacao]
    [Column("tra_vl_valor", TypeName = "decimal(18,2)")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A data é obrigatória")]
    [Column("tra_dt_data")]  
    public DateOnly Data { get; set; }

    [Column("tra_id_categoria")]
    public long? CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Categoria? Categoria { get; set; }

    [Required(ErrorMessage = "O tipo de transação é obrigatório")]
    [Column("tra_id_tipo_transacao")]
    public long TipoTransacaoId { get; set; }

    [ForeignKey("TipoTransacaoId")]
    public TipoTransacao? TipoTransacao { get; set; }

    [Required(ErrorMessage = "A indicação de crédito é obrigatória")]
    [Column("tra_fl_credito")]
    public bool IsCredito { get; set; }

    [Required(ErrorMessage = "A indicação de recorrência é obrigatória")]
    [Column("tra_fl_recorrente")]
    public bool IsRecorrente { get; set; }
}