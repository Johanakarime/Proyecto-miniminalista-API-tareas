using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
using TareaApi.Datos;
using TareaApi.Modelos;


var builder = WebApplication.CreateBuilder(args);

// Configurar serialización para enums como texto (string) y case-insensitive
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(null, allowIntegerValues: false));
});

builder.Services.AddDbContext<TareaBd>(opt =>
    opt.UseSqlite("Data Source=tareas.db"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// Endpoint para registrar tareas
app.MapPost("/tareas", async (Tarea tarea, TareaBd db) =>
{
    db.Tareas.Add(tarea);
    await db.SaveChangesAsync();
    return Results.Created($"/tareas/{tarea.Id}", tarea);
});

// Endpoint para obtener tareas completadas
app.MapGet("/tareas/completadas", async (TareaBd db) =>
{
    var completadas = await db.Tareas.Where(t => t.Estado == EstadoTarea.Completado).ToListAsync();
    return Results.Ok(completadas);
});

// Endpoint para filtrar tareas por texto en título y descripción

// Endpoint para actualizar una tarea
app.MapPut("/tareas/{id}", async (int id, Tarea tareaActualizada, TareaBd db) =>
{
    var tarea = await db.Tareas.FindAsync(id);
    if (tarea is null)
        return Results.NotFound();

    tarea.Titulo = tareaActualizada.Titulo;
    tarea.Descripcion = tareaActualizada.Descripcion;
    tarea.Estado = tareaActualizada.Estado;
    tarea.FechaCreacion = tareaActualizada.FechaCreacion;

    await db.SaveChangesAsync();
    return Results.Ok(tarea);
});

// Endpoint para eliminar una tarea
app.MapDelete("/tareas/{id}", async (int id, TareaBd db) =>
{
    var tarea = await db.Tareas.FindAsync(id);
    if (tarea is null)
        return Results.NotFound();

    db.Tareas.Remove(tarea);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint para filtrar tareas por texto en título y descripción
app.MapGet("/tareas/buscar", async (string texto, TareaBd db) =>
{
    var resultado = await db.Tareas
        .Where(t => t.Titulo.Contains(texto) || t.Descripcion.Contains(texto))
        .ToListAsync();
    return Results.Ok(resultado);
});

app.Run();
