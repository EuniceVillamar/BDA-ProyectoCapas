# Sistema de Gestión de Reparaciones

Este proyecto es un sistema de gestión para un taller de reparaciones, desarrollado en C# .NET 6.0 utilizando una arquitectura de capas.

## Estructura del Proyecto

El proyecto está organizado en tres capas principales:

- **CapaPresentacion**: Contiene la interfaz de usuario (Windows Forms)
- **CapaNegocio**: Contiene la lógica de negocio
- **CapaDatos**: Maneja el acceso a datos y la comunicación con la base de datos

## Características

- Gestión de clientes
- Gestión de técnicos
- Control de reparaciones
- Gestión de inventario de repuestos
- Generación de facturas
- Sistema de login y registro
- Gestión de dispositivos móviles

## Requisitos Previos

- Visual Studio 2022
- .NET 6.0 SDK
- SQL Server (2019 o superior)

## Configuración del Proyecto

1. Clonar el repositorio:
```bash
git clone [URL_DEL_REPOSITORIO]
cd ProyectoCapas
```

2. Restaurar la base de datos:
   - Abrir SQL Server Management Studio
   - Ejecutar el script `sqlbase.sql` para crear la base de datos

3. Configurar la conexión:
   - Abrir el archivo `CapaDatos/SQL/ConnectionDB.cs`
   - Actualizar la cadena de conexión según tu configuración local

4. Compilar y ejecutar:
   - Abrir la solución `ProyectoCapas.sln` en Visual Studio
   - Restaurar los paquetes NuGet
   - Compilar la solución
   - Ejecutar el proyecto

## Dependencias Principales

- iText7 (para generación de PDFs)
- System.Data.SqlClient
- Microsoft.Extensions.DependencyInjection
- Newtonsoft.Json

## Contribuir

1. Hacer fork del repositorio
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit a tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles. 