namespace Dominio
{
    public class EnfermedadCliente
    {
        public int IdCliente{ get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdEnfermedad { get; set; }
        public virtual Enfermedad Enfermedad { get; set; }
    }
}