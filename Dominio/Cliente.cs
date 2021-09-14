using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Dominio
{
    public class Cliente : BaseEntity
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Nombre{ get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Apellido{ get; set; }
        [Required]
        [Range(1,150), RegularExpression(@"^[-+]?[0-9]*\.?[0-9]+$")]
        public int Edad { get; set; }
        //Podria ser un enum o una clase
        [Required]
        [StringLength(20)]
        public string Genero { get; set; }
        [Required]
        public bool EsConductor { get; set; }
        [Required]
        public bool UsaLentes { get; set; }
        //Podria ser un enum o una clase
        [Required]
        public string Estado { get; set; }
        public void ActualizarEstado(string estado)
        {
            if (estado == "Activo" || estado == "Inactivo")
            {
                Estado = estado;
            }
            else
            {
                throw new Exception("Error al actualizar el estado");
            }
        }

        public Cliente()
        {
            Estado = "Activo";
            
        }

        public virtual ICollection<EnfermedadCliente> EnfermedadClientes { get; set; } = new List<EnfermedadCliente>();

        public void AgregarEnfermedad(Enfermedad enfermedad)
        {
            if (EnfermedadClientes != null)
            {
                EnfermedadClientes.Add(new EnfermedadCliente
                {
                    IdCliente = this.Id,
                    IdEnfermedad = enfermedad.Id,
                    Cliente = this,
                    Enfermedad = enfermedad
                });
            }
        }

        public bool RemoverEnfermedad(int idCliente, int idEnfermedad)
        {
            if (EnfermedadClientes.Any())
            {
                var enfermedadCliente = EnfermedadClientes.FirstOrDefault(x => x.IdEnfermedad == idEnfermedad && x.IdCliente == idCliente);
                if (enfermedadCliente == null) return false;
                EnfermedadClientes.Remove(enfermedadCliente);
                return true;
            }

            return false;
        }
    }
}