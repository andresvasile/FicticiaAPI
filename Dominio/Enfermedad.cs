using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Enfermedad : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<EnfermedadCliente> EnfermedadClientes { get; set; }
    }
}