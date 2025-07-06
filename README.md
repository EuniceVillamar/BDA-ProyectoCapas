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
git clone https://github.com/EuniceVillamar/BDA-ProyectoCapas.git
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

- System.Data.SqlClient
- Microsoft.Extensions.DependencyInjection
- Newtonsoft.Json
