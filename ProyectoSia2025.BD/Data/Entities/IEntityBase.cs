namespace ProyectoSia2025.BD.Data.Entities
{
    public interface IEntityBase
    {
        EnumEstadoRegistro Estado { get; set; }
        int Id { get; set; }
        string Observacion { get; set; }
    }
}