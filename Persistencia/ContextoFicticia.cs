using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class ContextoFicticia : DbContext
    {
        public ContextoFicticia(DbContextOptions<ContextoFicticia> options):base(options)
        {

        }

        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Enfermedad> Enfermedades{ get; set; }
    }
}