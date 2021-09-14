namespace Dominio
{
    public class Enfermedad : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCliente{ get; set; }
        public Cliente Cliente{ get; set; }
    }
}