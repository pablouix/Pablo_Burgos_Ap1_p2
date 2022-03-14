using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pablo_Burgos_Ap1_p2.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { set; get; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar descripción. ")]
        [MinLength(3, ErrorMessage = "La descripción debe tener almenos {1} caracteres.")]
        [MaxLength(35, ErrorMessage = "La descripción no debe pasar de {1} caracteres. ")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. poner fecha de vencimiento.")]
        public DateTime FechaDeVencimiento { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar la existencia.")]
        [Range(1, int.MaxValue, ErrorMessage = "Se debe indicar la existencia del producto dentro de los tangos {1}/{2}")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar el peso del producto.")]
        [Range(1, float.MaxValue, ErrorMessage = "Se debe indicar el peso del producto dentro de los tangos {1}/{2}")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "El campo \"Costo\" está vacío. Por favor indique un costo.")]
        [Range(1, float.MaxValue, ErrorMessage = "El costo debe estar dentro del rango permitido {1}/{2}.")]
        public float Costo { get; set; }
        public float ValorInventario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar el precio.")]
        [Range(1, float.MaxValue, ErrorMessage = "Se debe indicar el precio del producto dentro de los rangos {1}/{2}")]
        public float Precio { get; set; }
        [Range(1, 100, ErrorMessage = "La ganancia debe de estar entre 1 y 100")]
        public int Ganancia { get; set; }
        public float PesoTotal {get; set; }

        [ForeignKey("ProductoId")]
        public virtual List<ProductosDetalle> ProductosDetalle { get; set; } = new List<ProductosDetalle>();
    }
}