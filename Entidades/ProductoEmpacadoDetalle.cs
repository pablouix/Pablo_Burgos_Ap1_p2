using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Ap1_p2.Entidades
{
    public class ProductosEmpacadosDetalle
    {
        [Key]
        public int ProductoEmpacadosDetallesId {get; set;}
        public int ProductoEmpacadosId {set; get;}

        public string? Descripcion {set; get;}
        public int Cantidad {set; get; }
        public float Peso {set; get; }
        

        public Productos? _producto {get; set;}

        public ProductosEmpacadosDetalle? _productosEmpacadosDetalle {get; set;}
        public ProductosEmpacadosDetalle(string descripcion, int cantidad, float peso)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            Peso = peso;
        }

        public ProductosEmpacadosDetalle()
        {

        }
    }
}