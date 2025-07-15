using Microsoft.EntityFrameworkCore;

namespace SistemaFIME.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aquí puedes agregar tus DbSets cuando tengas modelos
        // public DbSet<Usuario> Usuarios { get; set; }
        // public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuraciones adicionales del modelo aquí
        }
    }
}