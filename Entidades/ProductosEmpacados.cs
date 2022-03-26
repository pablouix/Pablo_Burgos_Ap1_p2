using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pablo_Burgos_Ap1_p2.Entidades
{
    public class ProductosEmpacados
    {
        [Key]
        public int ProductoEmpacadosId {get; set;}
        //public int ProductosDetallesId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. poner fecha actual.")]
        public DateTime FechaCreacion {get; set;} = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar concepto. ")]
        [MinLength(3, ErrorMessage = "El concepto debe tener almenos {1} caracteres.")]
        [MaxLength(35, ErrorMessage = "El concepto no debe pasar de {1} caracteres. ")]
        public string Concepto { get; set; }

        
        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar la cantidad utilizados.")]
        [Range(0, int.MaxValue, ErrorMessage = "Se debe indicar la cantidad utilizada debe de estar dentro de los tangos {1}/{2}")]
        public int cantidadUtilizados { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar la cantidad producidos.")]
        [Range(0, int.MaxValue, ErrorMessage = "Se debe indicar la cantidad producido debe de estar dentro de los tangos {1}/{2}")]
        public int cantidadProducidos { get; set; }
        public int IdProducidos { get; set; } // conocer id 

        [ForeignKey("ProductoEmpacadosId")]
        public virtual List<ProductosEmpacadosDetalle> ProductosEmpacadosDetalle { get; set; } = new List<ProductosEmpacadosDetalle>();
    }
}