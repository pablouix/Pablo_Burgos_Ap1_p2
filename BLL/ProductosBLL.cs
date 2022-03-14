
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p2.DAL;
using Pablo_Burgos_Ap1_p2.Entidades;

namespace Pablo_Burgos_Ap1_p2.BLL
{
    public class ProductosBLL
    {
        private Contexto _contexto;

        public ProductosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private bool Existe(int id)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Productos.Any(p => p.ProductoId == id);

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Guardar(Productos producto)
        {
            if (Existe(producto.ProductoId))
                return Modificar(producto);
            else
                return Insertar(producto);
        }

        private bool Modificar(Productos producto)
        {
            bool paso = false;

            try
            {
              /*   _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductoDetalle where ProductoId={producto.ProductosDetalle}");

                foreach (var anterior in producto.ProductosDetalle)
                {
                    _contexto.Entry(anterior).State = EntityState.Added;
                } */

                _contexto.Entry(producto).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        private bool Insertar(Productos producto)
        {
            bool paso = false;

            try
            {
                _contexto.Productos.Add(producto);

                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }

            return paso;
        }


        public Productos Buscar(int id)
        {
            Productos producto;

            try
            {

                producto = _contexto.Productos.Include(x => x.ProductosDetalle).Where(p => p.ProductoId == id).SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        public Productos BuscarDescripcion(string descripcion)
        {
            Productos productos;

            try
            {
                productos = _contexto.Productos.Include(x => x.ProductosDetalle).Where(p => p.Descripcion == descripcion).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return productos;
        }


        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var producto = _contexto.Productos.Find(id);

                if (producto != null)
                {
                    _contexto.Productos.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            try
            {
                lista = _contexto.Productos.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
           public List<ProductosDetalle> GetListaDetalle()
           {
               List<ProductosDetalle> lista = new List<ProductosDetalle>();
               try
               {
                   lista = _contexto.ProductosDetalles.ToList();
                   //lista = _contexto.ProductosDetalles.Where(criterio).ToList();

               }
               catch (Exception)
               {
                   throw;
               }
               return lista;
           }

        public List<Productos> GetListaProductos()
        {
            List<Productos> lista = new List<Productos>();
            try
            {
                lista = _contexto.Productos.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}