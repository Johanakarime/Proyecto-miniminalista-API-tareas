# Proyecto-miniminalista-API-tareas

Este proyecto es una API minimalista desarrollada en .NET que permite gestionar tareas (crear, listar, actualizar y eliminar) usando Entity Framework Core con una base de datos SQLite. Incluye documentación interactiva con Swagger.

## Descripción
- CRUD de tareas (Crear, Leer, Actualizar, Eliminar)
- Filtros por estado y búsqueda por texto
- Persistencia en SQLite
- Documentación y pruebas interactivas con Swagger

## Pasos para correr el proyecto

1. Abre una terminal en la carpeta raíz del proyecto (donde está `TareaApi.slnx`).
2. Restaura los paquetes necesarios:
   ```
   dotnet restore
   ```
3. Compila el proyecto:
   ```
   dotnet build
   ```
4. Aplica las migraciones para crear la base de datos SQLite:
   ```
   dotnet ef database update --project TareaApi/TareaApi.csproj
   ```
5. Ejecuta la API:
   ```
   dotnet run --project TareaApi/TareaApi.csproj
   ```
6. Abre tu navegador y accede a Swagger para probar los endpoints:
    - [http://localhost:5199/swagger](http://localhost:5199/swagger) (o el puerto que indique tu configuración)
      
    6.1 Para ver tareas completadas:
   - Busca el endpoint GET /tareas/completadas.
   - Haz clic en "Try it out" o "Probar".
   - Haz clic en "Execute" o "Ejecutar".
   - Verás la lista de tareas con estado Completado en la respuesta.

    6.2 Para buscar tareas por texto:
   - Busca el endpoint GET /tareas/buscar.
   - Haz clic en "Try it out" o "Probar".
   - En el campo texto, escribe la palabra o frase que quieres buscar (por ejemplo: tarea).
   - Haz clic en "Execute" o "Ejecutar".
   - Verás la lista de tareas cuyo título o descripción contiene ese texto.
     
  

## Notas
- Si necesitas cambiar el puerto, revisa el archivo `TareaApi/Properties/launchSettings.json`.
- Swagger permite probar todos los endpoints de la API de manera interactiva.

---

¡Listo! puedes correr y probar el API de tareas.
