using System.ComponentModel.DataAnnotations;

namespace P1_AP_RomelOrtega.Models;

public class EntradaHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Por favor digitar el nombre.")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Por favor digitar la fecha.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Por favor digitar el precio.")]
    [Range(0, double.MaxValue, ErrorMessage = "No puede ser negativo")]
    [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
    public decimal Precio { get; set; } = 0;

    [Required(ErrorMessage = "Por favor digitar el monto.")]
    [Range(0, double.MaxValue, ErrorMessage = "No puede ser negativo")]
    public double Cantidad { get; set; } = 0;
}
