


using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p2.DAL;
using Pablo_Burgos_Ap1_p2.Entidades;

namespace Pablo_Burgos_Ap1_p2.BLL
{
    public class ProductosEmpacadosBLL
    {
        private Contexto _contexto;

        public ProductosEmpacadosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private bool Existe(int id)
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
        public bool Guardar(ProductosEmpacados productosEmpacados)
        {
            if (Existe(productosEmpacados.ProductoEmpacadosId))
                return Modificar(productosEmpacados);
            else
                return Insertar(productosEmpacados);
        }

        private bool Insertar(ProductosEmpacados productosEmpacados)
        {
            bool paso = false;

            try
            {
                _contexto.ProductosEmpacados.Add(productosEmpacados);

                foreach (var detalle in productosEmpacados.ProductosEmpacadosDetalle)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                   // _contexto.Entry(detalle._producto).State = EntityState.Modified;

                    //detalle._producto.Existencia -= detalle.Cantidad;

                }

                var producto = _contexto.Productos.Find(productosEmpacados.ProductoEmpacadosId).Existencia += productosEmpacados.cantidadProducidos;
                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }

            var producido = _contexto.Productos.Find(productosEmpacados.ProductoEmpacadosId).Existencia += productosEmpacados.cantidadProducidos;


            return paso;
        }

        private bool Modificar(ProductosEmpacados productosEmpacados)
        {
            bool paso = false;

            try
            {

                var entradaAnterior = _contexto.ProductosEmpacados.Where(x => x.ProductoEmpacadosId == productosEmpacados.ProductoEmpacadosId)
                .Include(x => x.ProductosEmpacadosDetalle)
               // .ThenInclude(x => x._producto)
                .AsNoTracking()
                .SingleOrDefault();

                foreach (var detalle in entradaAnterior.ProductosEmpacadosDetalle)
                {
                    //detalle._producto.Existencia += detalle.Cantidad;
                }

                var producido = _contexto.Productos.Find(productosEmpacados.ProductoEmpacadosId).Existencia -= productosEmpacados.cantidadProducidos;





                // _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductoDetalles where ProductoId={productoEmpacados.ProductoId}");

                foreach (var item in productosEmpacados.ProductosEmpacadosDetalle) 
                {

                    _contexto.Entry(item).State = EntityState.Added;
                    //_contexto.Entry(item._producto).State = EntityState.Modified;

                    //item._producto.Existencia -= item.Cantidad;
                }

                _contexto.Entry(productosEmpacados).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public ProductosEmpacados Buscar(int id)
        {
            ProductosEmpacados productosEmpacados;

            try
            {
                productosEmpacados = _contexto.ProductosEmpacados.Include(x => x.ProductosEmpacadosDetalle).Where(p => p.ProductoEmpacadosId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return productosEmpacados;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var productosEmpacados = _contexto.ProductosEmpacados.Find(id);

                if (productosEmpacados != null)
                {
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


        
        public List<ProductosEmpacados> GetList(Expression<Func<ProductosEmpacados, bool>> criterio)
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