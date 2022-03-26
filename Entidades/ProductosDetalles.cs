
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pablo_Burgos_Ap1_p2.Entidades
{
    public class ProductosDetalles
    {
        [Key]
        public int ProductosDetallesId { get; set; }
        public int ProductoId { get; set; } 
        public string? Presentacion { get; set; }
        public int Cantidad { get; set; }

        public float Precio { get; set; }
        public ProductosDetalles(string presentacion, int cantidad, float precio)
        {
            Presentacion = presentacion;
            Cantidad = cantidad;
            Precio = precio;
        }

        public  ProductosDetalles()
        {

        }

    }
}