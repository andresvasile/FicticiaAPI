using System.Threading.Tasks;
using Dominio;

namespace Persistencia.Interfaces
{
    public interface IEnfermedadRepository
    {
        Task<Enfermedad> AgregarEnfermedad(Enfermedad enfermedad);
        Task<Enfermedad> ActualizarEnfermedad(Enfermedad enfermedad);
        Task<Enfermedad> BorrarEnfermedad(Enfermedad enfermedad);
        Task<Enfermedad> ObtenerEnfermedadPorId(int id);
    }
}