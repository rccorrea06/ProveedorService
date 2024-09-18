using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ProveedorService.Infrastructure.MongoDb
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }
        
        public DbSet<Proveedor.Domain.Entities.Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Proveedor.Domain.Entities.Proveedor>().ToCollection("Proveedores");

        }

    }
}
