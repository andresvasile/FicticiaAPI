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
    public class EnfermedadController : ControllerBase
    {
        private readonly IEnfermedadRepository _enfermedadRepository;

        public EnfermedadController(IEnfermedadRepository enfermedadRepository)
        {
            _enfermedadRepository = enfermedadRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(Enfermedad enfermedad)
        {
            try
            {
                var enfermedadAgregado = await _enfermedadRepository.AgregarEnfermedad(enfermedad);

                if (enfermedadAgregado == null) return Ok("Error al agregar lA enfermedad");

                return Ok($"Se agrego lA enfermedad {enfermedadAgregado.Nombre} correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> Editar(Enfermedad enfermedad)
        {
            try
            {
                var enfermedadExiste = await _enfermedadRepository.ObtenerEnfermedadPorId(enfermedad.Id);

                if (enfermedadExiste == null) return Ok("La enfermedad no existe, ingrese una enfermedad valida");

                var enfermedadEditado = await _enfermedadRepository.ActualizarEnfermedad(enfermedad);

                if (enfermedadEditado == null) return Ok("Error al editar la enfermedad");

                return Ok($"Se edito la enfermedad {enfermedadEditado.Nombre} correctamente");

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
                var enfermedadExiste = await _enfermedadRepository.ObtenerEnfermedadPorId(id);

                if (enfermedadExiste == null) return Ok("La enfermedad no existe, ingrese un enfermedad valido");

                var enfermedadBorrado = await _enfermedadRepository.BorrarEnfermedad(enfermedadExiste);

                if (enfermedadBorrado == null) return Ok("Error al borrar la enfermedad");

                return Ok($"Se borro la enfermedad {enfermedadBorrado.Nombre} correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
