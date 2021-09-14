using System;
using Dominio;
using Persistencia.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoFicticia _contexto;

        public ClienteRepository(ContextoFicticia contexto)
        {
            _contexto = contexto;
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await _contexto.Clientes.Include(x => x.EnfermedadClientes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> AgregarCliente(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            var seCompleto = await _contexto.SaveChangesAsync();

            if (seCompleto < 0) return null;

            return await ObtenerClientePorId(cliente.Id);
        }

        public async Task<Cliente> ActualizarCliente(Cliente cliente)
        {
            var clienteAEditar = await ObtenerClientePorId(cliente.Id);

            if (clienteAEditar != null)
            {
                clienteAEditar.Nombre = cliente.Nombre ?? clienteAEditar.Nombre;
                clienteAEditar.Apellido = cliente.Apellido ?? clienteAEditar.Apellido;
                clienteAEditar.Genero = cliente.Genero ?? clienteAEditar.Genero;
                clienteAEditar.ActualizarEstado(cliente.Estado);
                clienteAEditar.Edad = cliente.Edad > 0 ? cliente.Edad : clienteAEditar.Edad;
                clienteAEditar.EsConductor = cliente.EsConductor;
                clienteAEditar.UsaLentes = cliente.UsaLentes;


                var seCompleto = await _contexto.SaveChangesAsync();
                if (seCompleto < 0) return null;

                return clienteAEditar;
            }

            return null;
        }

        public async Task<Cliente> BorrarCliente(Cliente clienteAEliminar)
        {
            _contexto.Clientes.Remove(clienteAEliminar);

            var seCompleto = await _contexto.SaveChangesAsync();

            if (seCompleto < 0) return null;

            return clienteAEliminar;

        }

        public async Task<bool> AgregarEnfermedadACliente(int id, Enfermedad enfermedad)
        {
            var clienteValido = await ObtenerClientePorId(id);

            var enfermedadValida = await _contexto.Enfermedades.FindAsync(enfermedad.Id);
            if (enfermedadValida == null) throw new Exception("La enfermedad no existe");

            clienteValido?.AgregarEnfermedad(enfermedadValida);

            var seCompleto = await _contexto.SaveChangesAsync();

            if (seCompleto < 0) throw new Exception("Error al agregar la enfermedad");

            return true;


        }

        public async Task<bool> RemoverEnfermedadACliente(int id, Enfermedad enfermedad)
        {
            var clienteValido = await ObtenerClientePorId(id);

            var enfermedadValida = await _contexto.Enfermedades.FindAsync(enfermedad.Id);
            if (enfermedadValida == null) throw new Exception("La enfermedad no existe");

            var enfermedadQuitada = clienteValido.RemoverEnfermedad(id,enfermedadValida.Id);

            if(!enfermedadQuitada) throw new Exception("Error al quitar la enfermedad");

            var seCompleto = await _contexto.SaveChangesAsync();

            if (seCompleto < 0) throw new Exception("Error al quitar la enfermedad");

            return true;
        }
    }
}