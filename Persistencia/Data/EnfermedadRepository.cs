using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Persistencia.Interfaces;

namespace Persistencia.Data
{
    public class EnfermedadRepository : IEnfermedadRepository
    {
        private readonly ContextoFicticia _contexto;

        public EnfermedadRepository(ContextoFicticia contexto)
        {
            _contexto = contexto;
        }

        public async Task<Enfermedad> ObtenerEnfermedadPorId(int id)
        {
            return await _contexto.Enfermedades.Include(x => x.EnfermedadClientes).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Enfermedad> AgregarEnfermedad(Enfermedad enfermedad)
        {
            _contexto.Enfermedades.Add(enfermedad);
            var seCompleto = await _contexto.SaveChangesAsync();
            if (seCompleto < 0) return null;
            return await ObtenerEnfermedadPorId(enfermedad.Id);
        }

        public async Task<Enfermedad> ActualizarEnfermedad(Enfermedad enfermedad)
        {
            var enfermedadAEditar = await ObtenerEnfermedadPorId(enfermedad.Id);

            if (enfermedadAEditar != null)
            {
                enfermedadAEditar.Nombre = enfermedad.Nombre ?? enfermedadAEditar.Nombre;
                enfermedadAEditar.Descripcion = enfermedad.Descripcion ?? enfermedadAEditar.Descripcion;


                var seCompleto = await _contexto.SaveChangesAsync();

                if (seCompleto < 0) return null;

                return enfermedadAEditar;
            }

            return null;
        }

        public async Task<Enfermedad> BorrarEnfermedad(Enfermedad enfermedad)
        {
            _contexto.Enfermedades.Remove(enfermedad);

            var seCompleto = await _contexto.SaveChangesAsync();

            if (seCompleto < 0) return null;

            return enfermedad;
        }
    }
}