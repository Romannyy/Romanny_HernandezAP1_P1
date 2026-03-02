using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Romanny_HernandezAP1_P1.Models;

public class EntradaDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int IdEntrada { get; set; }

    public int TipoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    [ForeignKey("TipoId")]
    public virtual TipoHuacales? TipoHuacal { get; set; }

    public virtual EntradasHuacales? EntradaHuacales { get; set; }
}