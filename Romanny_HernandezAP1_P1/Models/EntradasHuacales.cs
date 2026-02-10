using System.ComponentModel.DataAnnotations;

namespace Romanny_HernandezAP1_P1.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }
    [Required (ErrorMessage = "Campo ID requerido.")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "Campo fecha requerido.")]
    public string NombreCliente { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo nombre cliente requerido.")]
    public double Costo { get; set; }

}
