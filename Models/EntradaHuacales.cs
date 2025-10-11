using System.ComponentModel.DataAnnotations;
using P1_AP1_RomelOrtega.Models;

namespace P1_AP1_RomelOrtega.Models;

public class EntradaHuacales
{

    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Por favor digitar el nombre.")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Por favor digitar la fecha.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Por favor digitar el precio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
    [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
    public decimal Precio { get; set; } = 0;

    [Required(ErrorMessage = "Por favor digitar la cantidad.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
    public double Cantidad { get; set; } = 0;

    public decimal Importe => (decimal)Cantidad * Precio;

    public virtual ICollection<EntradasHuacalesDetalle> EntradasHuacalesDetalles { get; set; } = new List<EntradasHuacalesDetalle>();
}

