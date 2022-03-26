using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Ap1_p2.Entidades
{
    public class ProductosEmpacadosDetalle
    {
        [Key]
        public int ProductoEmpacadosDetallesId {get; set;}
        public int ProductoEmpacadosId {set; get;}


        public int IdProducto {set; get;}
        public string? Concepto {set; get;}
        public int Cantidad {set; get; }
        public float Peso {set; get; }


        
        public ProductosEmpacadosDetalle(int id, string concepto, int cantidad, float peso)
        {
            IdProducto = id;
            Concepto = concepto;
            Cantidad = cantidad;
            Peso = peso;
        }

        public ProductosEmpacadosDetalle()
        {

        }
    }
}