using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Persistencia.Interfaces;

namespace FicticiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(Cliente cliente)
        {
            try
            {
                var clienteAgregado = await _clienteRepository.AgregarCliente(cliente);

                if (clienteAgregado == null) return Ok("Error al agregar el cliente");

                return Ok($"Se agrego el cliente {clienteAgregado.Nombre} correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            try
            {
                var clienteExiste = await _clienteRepository.ObtenerClientePorId(cliente.Id);

                if (clienteExiste == null) return Ok("El cliente no existe, ingrese un cliente valido");

                var clienteEditado = await _clienteRepository.ActualizarCliente(cliente);

                if(clienteEditado==null) return Ok("Error al editar el cliente");

                return Ok($"Se edito el cliente {clienteEditado.Nombre} correctamente");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            try
            {
                var clienteExiste = await _clienteRepository.ObtenerClientePorId(id);

                if (clienteExiste == null) return Ok("El cliente no existe, ingrese un cliente valido");

                var clienteBorrado = await _clienteRepository.BorrarCliente(clienteExiste);

                if (clienteBorrado == null) return Ok("Error al borrar al cliente");

                return Ok($"Se borro al cliente {clienteBorrado.Nombre} correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("agregarEnfermedad/{id}")]
        public async Task<IActionResult> AgregarEnfermedad(int id, [FromBody] Enfermedad enfermedad)
        {
            try
            {
                var seCompleto = await _clienteRepository.AgregarEnfermedadACliente(id,enfermedad);
                if (!seCompleto) return Ok("Error al agregar la enfermedad");

                return Ok("La enfermedad se agrego correctamente");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("removerEnfermedad/{id}")]
        public async Task<IActionResult> RemoverEnfermedad(int id, [FromBody] Enfermedad enfermedad)
        {
            try
            {
                var seCompleto = await _clienteRepository.RemoverEnfermedadACliente(id, enfermedad);
                if (!seCompleto) return Ok("Error al quitar la enfermedad");

                return Ok("La enfermedad se quito correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
