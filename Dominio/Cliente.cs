using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Range(1,150), RegularExpression(@"^[-+]?[0-9]*\.?[0-9]+$")]
        public int Edad { get; set; }
        //Podria ser un enum o una clase
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(20)]
        public string Genero { get; set; }
        public bool EsConductor { get; set; }
        public bool UsaLentes { get; set; }
        //Podria ser un enum o una clase
        public bool Estado { get; set; }
        public virtual IEnumerable<Enfermedad> Enfermedades { get; set; }
    }
}