
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pablo_Burgos_Ap1_p2.Entidades
{
    public class ProductosDetalle
    {
        [Key]
        public int ProductosDetallesId { get; set; }
        public int ProductoId { get; set; } 

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar presentacion. ")]
        [MinLength(3, ErrorMessage ="La presentacion debe tener almenos {1} caracteres.")]
        [MaxLength(35, ErrorMessage ="La presentacion no debe pasar de {1} caracteres. ")]

        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="Campo obligatorio. Se debe indicar la cantidad.")]
        [Range(1, int.MaxValue, ErrorMessage = "Se debe indicar la cantidad del producto dentro de los rangos {1}/{2}")]
        public int Cantidad { get; set; }

        
        [Required(ErrorMessage ="Campo obligatorio. Se debe indicar el precio.")]
        [Range(1, float.MaxValue, ErrorMessage = "Se debe indicar el precio del producto dentro de los rangos {1}/{2}")]
        public float Precio { get; set; }


        [ForeignKey("ProductosDetallesId")]
        public virtual List<ProductosEmpacados> ProductosEmpacados { get; set; } = new List<ProductosEmpacados>();
        public ProductosDetalle(string descripcion, int cantidad, float precio)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
        }

        public  ProductosDetalle()
        {

        }

    }
}