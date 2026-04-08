using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Romanny_HernandezAP1_P1.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Campo fecha requerido.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Campo nombre cliente requerido.")]
    public string NombreCliente { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    [ForeignKey("IdEntrada")]
    public virtual ICollection<EntradaDetalle> Detalle { get; set; } = [];
}