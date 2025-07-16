# SistemaFIME - Comunidad Docente FIME

Sistema web para la comunidad docente de la Facultad de Ingeniería Mecánica y Eléctrica.

## 🚀 Desarrollo Rápido (Hot Reload)

Para desarrollo con recarga automática de cambios:

```bash
./start-dev.sh
```

Esto iniciará el proyecto en modo desarrollo donde:
- ✅ Los cambios en archivos `.razor`, `.cshtml`, `.cs` se ven instantáneamente
- ✅ No necesitas reconstruir el contenedor
- ✅ Hot reload automático habilitado
- ✅ Base de datos PostgreSQL incluida

## 🏭 Producción

Para ejecutar en modo producción:

```bash
docker-compose up -d --build
```

## 📋 Requisitos

- Docker
- Docker Compose

## 🌐 Acceso

- **Aplicación**: http://localhost:8080
- **Base de datos**: localhost:5432

## 🛠️ Comandos Útiles

### Desarrollo
```bash
# Iniciar desarrollo con hot reload
./start-dev.sh

# Detener contenedores de desarrollo
docker-compose -f docker-compose.dev.yml down

# Ver logs en tiempo real
docker-compose -f docker-compose.dev.yml logs -f web
```

### Producción
```bash
# Iniciar producción
docker-compose up -d --build

# Detener producción
docker-compose down

# Ver logs
docker-compose logs -f web
```

## 📁 Estructura del Proyecto

- `Pages/` - Páginas Razor y componentes Blazor
- `Data/` - Contexto de base de datos y modelos
- `wwwroot/` - Archivos estáticos (CSS, JS, imágenes)
- `docker-compose.yml` - Configuración de producción
- `docker-compose.dev.yml` - Configuración de desarrollo
- `Dockerfile` - Imagen de producción
- `Dockerfile.dev` - Imagen de desarrollo con hot reload

## SistemaFIME

Sistema web desarrollado en **Blazor Server** con ASP.NET Core 9.0 y PostgreSQL.

## ✨ Características

- **Blazor Server**: Interfaz de usuario interactiva con C#
- **PostgreSQL**: Base de datos robusta y escalable
- **JavaScript Vanilla**: Sin dependencias de jQuery o Bootstrap
- **CSS Personalizado**: Diseño limpio y responsivo
- **Docker**: Despliegue fácil y consistente

## 🚀 Inicio Rápido con Docker

### Prerrequisitos
- Docker
- Docker Compose

### Ejecutar la aplicación

1. **Opción 1: Script automático**
   ```bash
   ./start.sh
   ```

2. **Opción 2: Comandos manuales**
   ```bash
   # Construir y levantar los servicios
   docker-compose up --build -d
   
   # Ver logs
   docker-compose logs -f
   
   # Detener servicios
   docker-compose down
   ```

### Acceso a los servicios

- **Aplicación web**: http://localhost:8080
- **Base de datos PostgreSQL**: localhost:5432
  - Base de datos: `sistemafime_db`
  - Usuario: `sistemafime_user`
  - Contraseña: `sistemafime_password`

## 🛠️ Desarrollo

### Estructura del proyecto
```
SistemaFIME/
├── Data/
│   └── ApplicationDbContext.cs    # Contexto de Entity Framework
├── Pages/                         # Razor Pages
├── wwwroot/                       # Archivos estáticos
├── Dockerfile                     # Configuración Docker
├── docker-compose.yml            # Orquestación de servicios
└── Program.cs                     # Punto de entrada
```

### Comandos útiles

```bash
# Ver logs de la aplicación
docker-compose logs web

# Ver logs de la base de datos
docker-compose logs postgres

# Acceder al contenedor de la aplicación
docker-compose exec web bash

# Acceder a PostgreSQL
docker-compose exec postgres psql -U sistemafime_user -d sistemafime_db

# Reconstruir solo la aplicación
docker-compose up --build web
```

## 📝 Configuración

### Variables de entorno
Las variables de entorno se configuran en `docker-compose.yml`:

- `ASPNETCORE_ENVIRONMENT`: Entorno de la aplicación
- `ConnectionStrings__DefaultConnection`: Cadena de conexión a PostgreSQL

### Persistencia de datos
Los datos de PostgreSQL se almacenan en un volumen Docker llamado `postgres_data` para persistir entre reinicios.

## 🔧 Personalización

Para agregar nuevos modelos y funcionalidades:

1. Crear modelos en el directorio `Models/`
2. Agregar DbSets al `ApplicationDbContext`
3. Crear migraciones: `dotnet ef migrations add NombreMigracion`
4. Aplicar migraciones: `dotnet ef database update`