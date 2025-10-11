using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P1_AP1_RomelOrtega.Models;

namespace P1_AP1_RomelOrtega.Models
{
    public class EntradasHuacalesDetalle
    {
        [Key]
        public int detalleId { get; set; }

        public int IdEntrada { get; set; }

        public int IdTipo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }


        [ForeignKey("IdEntrada")]
        [InverseProperty("EntradasHuacalesDetalles")]
        public virtual EntradaHuacales EntradaHuacal { get; set; }

        public virtual ICollection<EntradaHuacales> EntradaHuacalesDetalle { get; set; }
       
        [ForeignKey("IdTipo")]
        public virtual TiposHuacales TipoHuacal { get; set; }
    }
}
