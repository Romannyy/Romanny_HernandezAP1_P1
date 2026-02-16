using System.ComponentModel.DataAnnotations;

namespace Romanny_HernandezAP1_P1.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }
    [Required (ErrorMessage = "Campo fecha requerido.")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "Campo nombre cliente requerido.")]
    public string NombreCliente { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo costo querido.")]
    public double Costo { get; set; }

}
