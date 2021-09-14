using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class ContextoFicticia : DbContext
    {
        public ContextoFicticia(DbContextOptions<ContextoFicticia> options):base(options)
        {

        }

        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Enfermedad> Enfermedades{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(x => x.Id);

            modelBuilder.Entity<Enfermedad>().HasKey(x => x.Id);

            modelBuilder.Entity<EnfermedadCliente>().HasKey(ec => new { ec.IdCliente, ec.IdEnfermedad });
            modelBuilder.Entity<EnfermedadCliente>()
                .HasOne(x => x.Cliente)
                .WithMany(x => x.EnfermedadClientes);
            modelBuilder.Entity<EnfermedadCliente>()
                .HasOne(x => x.Enfermedad)
                .WithMany(x => x.EnfermedadClientes);
            base.OnModelCreating(modelBuilder);
        }
    }
}