
using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p2.Entidades;

namespace Pablo_Burgos_Ap1_p2.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosDetalle> ProductosDetalles { get; set; }
        public DbSet<ProductosEmpacados> ProductosEmpacados { get; set; }
        public DbSet<ProductosEmpacadosDetalle> ProductosEmpacadosDetalle { get; set; }


        public Contexto(DbContextOptions<Contexto> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().Property(m => m.Descripcion);
            base.OnModelCreating(modelBuilder);
        } 
    }
}