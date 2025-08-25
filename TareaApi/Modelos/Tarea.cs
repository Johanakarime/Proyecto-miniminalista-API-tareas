namespace TareaApi.Modelos;

public enum EstadoTarea
{
    Pendiente,
    EnProgreso,
    Completado
}

public class Tarea
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
           