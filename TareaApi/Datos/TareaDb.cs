using Microsoft.EntityFrameworkCore;
using TareaApi.Modelos;

namespace TareaApi.Datos;

public class TareaBd : DbContext
{
    public TareaBd(DbContextOptions<TareaBd> options)
    :  base (options){}

    public DbSet<Tarea> Tareas { get; set; }
}
