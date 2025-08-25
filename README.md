# API Minimalista de Tareas (.NET + SQLite)

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
   - [http://localhost:5000/swagger](http://localhost:5000/swagger) (o el puerto que indique tu configuración)

## Notas
- Si necesitas cambiar el puerto, revisa el archivo `TareaApi/Properties/launchSettings.json`.
- Swagger te permite probar todos los endpoints de la API de manera interactiva.

---

¡Listo! Así puedes correr y probar tu API de tareas.
