using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAPI.Models
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Producto> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Siembra de datos de productos
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Laptop",
                    Categoria = "Electrónica",
                    Descripcion = "Una laptop de lato rendimiento."
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Smartphone",
                    Categoria = "Electrónica",
                    Descripcion = "Un smartphone de nueva generacion."
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Silla de escritorio",
                    Categoria = "Muebles",
                    Descripcion = "Una silla de escritorio cómoda."
                }
             );
        }
    }
}
