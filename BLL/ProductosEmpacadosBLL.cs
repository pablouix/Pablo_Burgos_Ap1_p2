
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p2.DAL;
using Pablo_Burgos_Ap1_p2.Entidades;

namespace Pablo_Burgos_Ap1_p2.BLL
{
    public class ProductosEmpacadosBLL
    {
        private static Contexto _contexto;
        
        public ProductosEmpacadosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private static bool Existe(int id)
        {
            bool paso = false;

            try
            {
                paso = _contexto.ProductosEmpacados.Any(p => p.ProductoEmpacadosId == id);

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Guardar(ProductosEmpacados productosEmpacados)
        {
            if (Existe(productosEmpacados.ProductoEmpacadosId))
                return Modificar(productosEmpacados);
            else
                return Insertar(productosEmpacados);
        }

        private static bool Insertar(ProductosEmpacados productosEmpacados)
        {
            bool paso = false;

            try
            {
                _contexto.ProductosEmpacados.Add(productosEmpacados);

                List<ProductosEmpacadosDetalle> productosEmpacadosDetalles = productosEmpacados.ProductosEmpacadosDetalle;
                foreach (var item in productosEmpacadosDetalles)
                {
                    Productos producto = ProductosBLL.Buscar(item.IdProducto);
                    producto.Existencia -= item.Cantidad;
                    //ProductosBLL.Guardar(producto);
                }
                Productos productos = ProductosBLL.Buscar(productosEmpacados.IdProducidos);
                productos.Existencia += productosEmpacados.cantidadProducidos;
                //ProductosBLL.Guardar(productos);

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private static bool Modificar(ProductosEmpacados productosEmpacados)
        {
            bool paso = false;

            try
            {
                var entradaAnterior = _contexto.ProductosEmpacados.Where(x => x.ProductoEmpacadosId == productosEmpacados.ProductoEmpacadosId)
                .Include(x => x.ProductosEmpacadosDetalle)
                //.AsNoTracking()
                .SingleOrDefault();

                foreach (var item in entradaAnterior.ProductosEmpacadosDetalle) //ojo entradaAnterior.ProductosEmpacadosDetalle
                {
                    Productos producto = ProductosBLL.Buscar(item.IdProducto);
                    producto.Existencia -= item.Cantidad;
                    //ProductosBLL.Guardar(producto);
                }
                Productos productosAnterior = ProductosBLL.Buscar(entradaAnterior.IdProducidos);
                productosAnterior.Existencia -= entradaAnterior.cantidadProducidos;
                //ProductosBLL.Guardar(productosAnterior);

                List<ProductosEmpacadosDetalle> productosEmpacadosDetalles = productosEmpacados.ProductosEmpacadosDetalle;
                foreach (var item in productosEmpacadosDetalles)
                {
                    Productos producto = ProductosBLL.Buscar(item.IdProducto);
                    producto.Existencia += item.Cantidad;
                    //ProductosBLL.Guardar(producto);
                }

                Productos productos = ProductosBLL.Buscar(productosEmpacados.IdProducidos);
                productos.Existencia += productosEmpacados.cantidadProducidos;
                //ProductosBLL.Guardar(productos);

                _contexto.Entry(productosEmpacados).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public static ProductosEmpacados Buscar(int id)
        {
            ProductosEmpacados productosEmpacados;

            try
            {
                productosEmpacados = _contexto.ProductosEmpacados
                            .Include(x => x.ProductosEmpacadosDetalle)
                            .Where(p => p.ProductoEmpacadosId == id)
                            //.AsNoTracking()
                            .SingleOrDefault();
            } 
            catch (Exception)
            {
                throw;
            }

            return productosEmpacados;
        }
            //reparar ojo 
        public static bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var productosEmpacados = _contexto.ProductosEmpacados.Find(id);

                if (productosEmpacados != null)
                {

                    List<ProductosEmpacadosDetalle> productosEmpacadosDetalles = productosEmpacados.ProductosEmpacadosDetalle;

                    foreach (var item in productosEmpacadosDetalles)
                    {
                        Productos producto = ProductosBLL.Buscar(item.IdProducto);
                        producto.Existencia += item.Cantidad;
                    }

                    Productos productos = ProductosBLL.Buscar(productosEmpacados.IdProducidos);
                    productos.Existencia -= productosEmpacados.cantidadProducidos;

                    _contexto.ProductosEmpacados.Remove(productosEmpacados);
                    paso = _contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static List<ProductosEmpacados> GetList(Expression<Func<ProductosEmpacados, bool>> criterio)
        {
            List<ProductosEmpacados> lista = new List<ProductosEmpacados>();
            try
            {
                lista = _contexto.ProductosEmpacados.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}