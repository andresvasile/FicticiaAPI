using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> ObtenerClientePorId(int id);
        Task<Cliente> AgregarCliente(Cliente cliente);
        Task<Cliente> ActualizarCliente(Cliente cliente);
        Task<Cliente> BorrarCliente(Cliente cliente);
        Task<bool> AgregarEnfermedadACliente(int ide, Enfermedad enfermedad);
        Task<bool> RemoverEnfermedadACliente(int id, Enfermedad enfermedad);

    }
}