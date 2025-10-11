using System.ComponentModel.DataAnnotations;

namespace P1_AP1_RomelOrtega.Models
{
    public class TiposHuacales
    {
        [Key]
        public int IdTipo { get; set; }


        [StringLength(100)]
        public string Descripcion { get; set; } = string.Empty;

        public int Existencia { get; set; }

        public List<EntradasHuacalesDetalle> Detalles { get; set; } = new List<EntradasHuacalesDetalle>();
        public int TipoId { get; internal set; }
    }
}
