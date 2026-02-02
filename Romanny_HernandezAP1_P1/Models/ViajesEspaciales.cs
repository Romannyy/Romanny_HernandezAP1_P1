using System.ComponentModel.DataAnnotations;

namespace Romanny_HernandezAP1_P1.Models;

public class ViajesEspaciales
{
    [Key]
    public int ViajeId { get; set; }
    [Required (ErrorMessage = "Campo requerido.")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "Campo requerido.")]
    public string Descripción { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo requerido.")]
    public double Costo { get; set; }

}
