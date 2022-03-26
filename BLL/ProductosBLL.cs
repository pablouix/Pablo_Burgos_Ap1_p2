
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p2.DAL;
using Pablo_Burgos_Ap1_p2.Entidades;

namespace Pablo_Burgos_Ap1_p2.BLL
{
    public class ProductosBLL
    {
        private static Contexto _contexto;
        public ProductosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private static bool Existe(int id)
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

        public static bool Guardar(Productos producto)
        {
            if (Existe(producto.ProductoId))
                return Modificar(producto);
            else
                return Insertar(producto);
        }

        private static bool Modificar(Productos producto)
        {
            bool paso = false;

            try
            {
                _contexto.Entry(producto).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        private static bool Insertar(Productos producto)
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


        public static Productos Buscar(int id)
        {
            Productos producto;

            try
            {
                producto = _contexto.Productos
                            .Include(x => x.ProductosDetalles)
                            .Where(p => p.ProductoId == id)
                            //.AsNoTracking()
                            .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        public static Productos BuscarDescripcion(string descripcion)
        {
            Productos productos;

            try
            {
                productos = _contexto.Productos.Include(x => x.ProductosDetalles).Where(p => p.Descripcion == descripcion).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return productos;
        }


        public static bool Eliminar(int id)
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

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            try
            {
                lista = _contexto.Productos.Where(criterio).AsNoTracking().ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        public static List<Productos> GetListaProductos()
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