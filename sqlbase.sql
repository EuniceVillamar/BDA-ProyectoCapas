--CREATE DATABASE DB_Reparaciones

-- Usar la base de datos
USE DB_Reparaciones;

-- Configurar opciones de la base de datos
ALTER DATABASE DB_Reparaciones SET RECOVERY FULL;
ALTER DATABASE DB_Reparaciones SET AUTO_SHRINK OFF;
ALTER DATABASE DB_Reparaciones SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE DB_Reparaciones SET TRUSTWORTHY ON;

PRINT 'Configuración de base de datos completada.';
-- Eliminamos las tablas si ya existen
DROP TABLE IF EXISTS tb_tecnico_equipo;
DROP TABLE IF EXISTS tb_reparacion;
DROP TABLE IF EXISTS tb_equipo_Movil;
DROP TABLE IF EXISTS tb_tecnico;
DROP TABLE IF EXISTS tb_cliente;
DROP TABLE IF EXISTS tb_reparacion_repuestos;
DROP TABLE IF EXISTS tb_repuestos;

-- Creaci n de tablas
CREATE TABLE tb_cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY, 
    cedula_cliente VARCHAR(10) UNIQUE NOT NULL, 
    nombre_cliente VARCHAR(50) NOT NULL,
    telefono_cliente VARCHAR(15),
    email_cliente VARCHAR(50)
);

CREATE TABLE tb_tecnico (
    id_tecnico INT IDENTITY(1,1) PRIMARY KEY, 
    cedula_tecnico VARCHAR(10) UNIQUE NOT NULL, 
    nombre_tecnico VARCHAR(50) NOT NULL,
    telefono_tecnico VARCHAR(15),
    email_tecnico VARCHAR(50)
);

CREATE TABLE tb_equipo_Movil (
    id_equipo INT IDENTITY(1,1) PRIMARY KEY, 
    imei_celular VARCHAR(15) UNIQUE NOT NULL, 
    cedula_cliente VARCHAR(10) NOT NULL, 
    descripcion_equipo VARCHAR(100),
    estado VARCHAR(20) DEFAULT 'En revision',
    fecha_ingreso DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (cedula_cliente) REFERENCES tb_cliente(cedula_cliente)
);

CREATE TABLE tb_reparacion (
    id_reparacion INT IDENTITY(1,1) PRIMARY KEY,
    cedula_cliente VARCHAR(10) NOT NULL,
    imei_celular VARCHAR(15) NOT NULL,
    descripcion_reparacion VARCHAR(255),
    costo DECIMAL(10,2) DEFAULT 0 CHECK (costo >= 0),
    estado VARCHAR(20),
    fecha_ingreso DATETIME,
    fecha_entrega VARCHAR(10) DEFAULT '13/01/2025',
    id_equipo INT, 
    id_cliente INT,
	
    FOREIGN KEY (cedula_cliente) REFERENCES tb_cliente(cedula_cliente),
    FOREIGN KEY (imei_celular) REFERENCES tb_equipo_Movil(imei_celular),
    FOREIGN KEY (id_equipo) REFERENCES tb_equipo_Movil(id_equipo),
    FOREIGN KEY (id_cliente) REFERENCES tb_cliente(id_cliente),
);

CREATE TABLE tb_reparacion_tecnico (
    id_equipo INT NOT NULL,
    id_tecnico INT NOT NULL,
    PRIMARY KEY (id_equipo, id_tecnico),
    FOREIGN KEY (id_equipo) REFERENCES tb_equipo_Movil(id_equipo),
    FOREIGN KEY (id_tecnico) REFERENCES tb_tecnico(id_tecnico),
);
CREATE TABLE tb_tecnico_equipo (
    id_tecnico INT, 
    id_equipo INT,  
    cedula_tecnico VARCHAR(10) NOT NULL, 
    imei_celular VARCHAR(15) NOT NULL, 
    descripcion_equipo VARCHAR(100),
    estado VARCHAR(20) DEFAULT 'En revision',
    fecha_ingreso DATETIME DEFAULT GETDATE(),
    id_cliente INT,

    PRIMARY KEY (cedula_tecnico, imei_celular),
    FOREIGN KEY (imei_celular) REFERENCES tb_equipo_Movil(imei_celular) ON DELETE NO ACTION,
    FOREIGN KEY (id_tecnico) REFERENCES tb_tecnico(id_tecnico) ON DELETE NO ACTION,
    FOREIGN KEY (id_equipo) REFERENCES tb_equipo_Movil(id_equipo) ON DELETE NO ACTION,
    FOREIGN KEY (cedula_tecnico) REFERENCES tb_tecnico(cedula_tecnico) ON DELETE NO ACTION
);


-- Creación de la tabla factura
CREATE TABLE tb_factura (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT,
    cedula_cliente VARCHAR(10),
    nombre_cliente VARCHAR(50),
    telefono_cliente VARCHAR(15),
    email_cliente VARCHAR(50),
    id_tecnico INT,
    cedula_tecnico VARCHAR(10),
    nombre_tecnico VARCHAR(50),
    telefono_tecnico VARCHAR(15),
    email_tecnico VARCHAR(50),
    id_equipo INT,
    imei_celular VARCHAR(15),
    descripcion_equipo VARCHAR(100),
    estado VARCHAR(20),
    fecha_ingreso DATETIME,
    id_reparacion INT,
    descripcion_reparacion VARCHAR(255),
    costo DECIMAL(10,2),
    fecha_entrega VARCHAR(10),
	tecnicos NVARCHAR(MAX),
    FOREIGN KEY (id_cliente) REFERENCES tb_cliente(id_cliente) ON DELETE NO ACTION,
    FOREIGN KEY (id_tecnico) REFERENCES tb_tecnico(id_tecnico) ON DELETE NO ACTION,
    FOREIGN KEY (id_equipo) REFERENCES tb_equipo_Movil(id_equipo) ON DELETE NO ACTION,
    FOREIGN KEY (id_reparacion) REFERENCES tb_reparacion(id_reparacion) ON DELETE NO ACTION
);
CREATE TABLE tb_repuestos (
    id_repuesto INT IDENTITY(1,1) PRIMARY KEY,
    descripcion_repuesto NVARCHAR(255) NOT NULL,
    cantidad_repuesto INT NOT NULL CHECK (cantidad_repuesto > 0),
    costo_individual DECIMAL(10,2) NOT NULL CHECK (costo_individual >= 0),
    costo_total_repuesto AS (cantidad_repuesto * costo_individual) PERSISTED
);

CREATE TABLE tb_servicios (
    id_servicio INT IDENTITY(1,1) PRIMARY KEY,
    descripcion_servicio NVARCHAR(255) NOT NULL,
    costo_servicio DECIMAL(10,2) NOT NULL CHECK (costo_servicio >= 0)
);
CREATE TABLE tb_reparacion_repuestos (
    id_equipo INT NOT NULL,
    id_repuesto INT NOT NULL,
    PRIMARY KEY (id_equipo, id_repuesto),
    FOREIGN KEY (id_equipo) REFERENCES tb_equipo_Movil(id_equipo),
    FOREIGN KEY (id_repuesto) REFERENCES tb_repuestos(id_repuesto)
);

-- Inserciones de datos en la tabla de clientes
INSERT INTO tb_cliente (cedula_cliente, nombre_cliente, telefono_cliente, email_cliente)
VALUES 
('0912345678', 'Juan Pérez', '0987654321', 'juan.perez@gmail.com'),
('0923456789', 'Ana Torres', '0998765432', 'ana.torres@gmail.com'),
('0911122233', 'Carlos López', '0991122334', 'carlos.lopez@gmail.com'),
('0922233344', 'Daniela Martínez', '0992233445', 'daniela.martinez@gmail.com');

-- Asegúrate de que los técnicos estén previamente insertados
INSERT INTO tb_cliente (cedula_cliente, nombre_cliente, telefono_cliente, email_cliente)
VALUES ('0945678901', 'Cliente Ejemplo', '0990000000', 'cliente.ejemplo@gmail.com');
-- Inserciones de datos en la tabla de técnicos
INSERT INTO tb_tecnico (cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico)
VALUES 
('0934567890', 'Luis Rivera', '0999123456', 'luis.rivera@gmail.com'),
('0945678901', 'María Sánchez', '0987654321', 'maria.sanchez@gmail.com'),
('0956789012', 'Javier Torres', '0993344556', 'javier.torres@gmail.com');

-- Asegúrate de que el técnico esté insertado antes de asociarlo al equipo
INSERT INTO tb_tecnico (cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico)
VALUES ('0989012345', 'Carlos Gómez', '0998765432', 'carlos.gomez@gmail.com');
-- Inserciones de datos en la tabla de equipos móviles
INSERT INTO tb_equipo_Movil (imei_celular, cedula_cliente, descripcion_equipo, estado)
VALUES 
('123456789012345', '0912345678', 'Galaxy 12', 'En revision'),
('234567890123456', '0923456789', 'Nokia L3150', 'Reparado'),
('345678901234567', '0911122233', 'Tablet Samsung Galaxy', 'En revision'),
('456789012345678', '0922233344', 'Smartphone Motorola G', 'En proceso'),
('678901234567890', '0945678901', 'Pantalla táctil', 'En revision');
-- Asignación de técnicos a equipos
INSERT INTO tb_tecnico_equipo (cedula_tecnico, imei_celular, id_tecnico, id_equipo, descripcion_equipo, estado, fecha_ingreso, id_cliente)
VALUES 
('0934567890', '123456789012345', 1, 1, 'APPLE 8', 'En revision', GETDATE(), 1),
('0945678901', '123456789012345', 2, 1, 'REDMI', 'En revision', GETDATE(), 1),
('0956789012', '123456789012345', 3, 1, 'Samsung', 'En revision', GETDATE(), 1),
('0989012345', '345678901234567', 3, 3, 'Samsung', 'En revision', GETDATE(), 2);
-- Inserciones de datos en la tabla de reparaciones
INSERT INTO tb_reparacion (cedula_cliente, imei_celular, id_cliente, id_equipo, descripcion_reparacion, costo, estado, fecha_ingreso)
VALUES 
('0912345678', '123456789012345', 1, 1, 'Reemplazo de batería', 50.00, 'En proceso', GETDATE()),
('0912345678', '123456789012345', 1, 3, 'Reemplazo de cámara trasera', 85.00, 'En proceso', GETDATE()),
('0945678901', '678901234567890', 2, 5, 'Reemplazo de pantalla táctil', 100.00, 'En proceso', GETDATE());
-- Inserciones de datos en la tabla de relación entre reparaciones y técnicos
INSERT INTO tb_reparacion_tecnico (id_equipo, id_tecnico)
VALUES 
(1, 1),  -- Técnico 1
(1, 2),  -- Técnico 2
(2, 3);  -- Técnico 3
-- Relación de técnico con reparación en otro registro
INSERT INTO tb_reparacion_tecnico (id_equipo, id_tecnico)
VALUES 
(3, 4);  -- Técnico 4
-- Inserción de datos en la tabla tb_factura
INSERT INTO tb_factura (
    id_cliente, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente,
    id_tecnico, cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico,
    id_equipo, imei_celular, descripcion_equipo, estado, fecha_ingreso,
    id_reparacion, descripcion_reparacion, costo, fecha_entrega, tecnicos
)VALUES (
    1, '0912345678', 'Juan Pérez', '0987654321', 'juan.perez@gmail.com',
    1, '0934567890', 'Luis Rivera', '0999123456', 'luis.rivera@gmail.com',
    1, '123456789012345', 'Galaxy 12', 'En revision', GETDATE(),
    1, 'Reemplazo de batería', 50.00, '13/01/2025', 'Luis Rivera, María Sánchez');
INSERT INTO tb_factura (
    id_cliente, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente,
    id_tecnico, cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico,
    id_equipo, imei_celular, descripcion_equipo, estado, fecha_ingreso,
    id_reparacion, descripcion_reparacion, costo, fecha_entrega, tecnicos
)VALUES (
    2, '0923456789', 'Ana Torres', '0998765432', 'ana.torres@gmail.com',
    3, '0956789012', 'Javier Torres', '0993344556', 'javier.torres@gmail.com',
    2, '234567890123456', 'Nokia L3150', 'Reparado', GETDATE(),
    2, 'Reemplazo de cámara trasera', 85.00, '13/01/2025', 'Javier Torres'
);
INSERT INTO tb_factura (
    id_cliente, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente,
    id_tecnico, cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico,
    id_equipo, imei_celular, descripcion_equipo, estado, fecha_ingreso,
    id_reparacion, descripcion_reparacion, costo, fecha_entrega, tecnicos
)VALUES (
    3, '0911122233', 'Carlos López', '0991122334', 'carlos.lopez@gmail.com',
    4, '0989012345', 'Carlos Gómez', '0998765432', 'carlos.gomez@gmail.com',
    3, '345678901234567', 'Tablet Samsung Galaxy', 'En revision', GETDATE(),
    3, 'Reemplazo de pantalla táctil', 100.00, '13/01/2025', 'Carlos Gomez'
);

-- Insertar servicios de ejemplo
INSERT INTO tb_servicios (descripcion_servicio, costo_servicio)
VALUES 
('Diagnóstico básico', 10.00),
('Reparación de pantalla', 50.00),
('Cambio de batería', 30.00),
('Reparación de cámara', 40.00),
('Limpieza interna', 15.00),
('Actualización de software', 20.00),
('Recuperación de datos', 35.00);
SELECT * FROM tb_cliente;
SELECT * FROM tb_tecnico;
SELECT * FROM tb_equipo_Movil;
SELECT * FROM tb_reparacion;
SELECT * FROM tb_tecnico_equipo;
SELECT * FROM tb_factura;
SELECT * FROM tb_repuestos;
SELECT * FROM tb_servicios;

GO
CREATE PROCEDURE SP_INSERT_EQUIPO
    @IMEI VARCHAR(15),
    @Cedula_cliente VARCHAR(10),
    @Descripcion VARCHAR(100),
    @Estado VARCHAR(20)
AS
BEGIN
    INSERT INTO tb_equipo_Movil (imei_celular, cedula_cliente, descripcion_equipo, estado)
    VALUES (@IMEI, @Cedula_cliente, @Descripcion, @Estado);
END;
GO
CREATE PROCEDURE SP_INSERT_REPARACION
    @Codigo_cliente INT,
    @Codigo_equipo INT,
	@Cedula_cliente VARCHAR(10),
    @IMEI VARCHAR(15),
    @descripcion VARCHAR(255),
    @costo DECIMAL(10,2)
AS
BEGIN
    DECLARE @estado_actual VARCHAR(20);
    DECLARE @fecha_ingreso_actual DATETIME;

    SELECT @estado_actual = estado, 
           @fecha_ingreso_actual = fecha_ingreso
    FROM tb_equipo_Movil
    WHERE  imei_celular = @IMEI;

    INSERT INTO tb_reparacion (cedula_cliente, imei_celular, id_cliente, id_equipo, descripcion_reparacion, costo, estado, fecha_ingreso)
    VALUES (@Cedula_Cliente, @IMEI, @Codigo_cliente, @Codigo_equipo, @descripcion, @costo, @estado_actual, @fecha_ingreso_actual);
END;
GO

CREATE PROCEDURE SP_INSERT_TECNICO
    @Cedula VARCHAR(10),
    @Nombre_tecnico VARCHAR(50),
    @Telefono_tecnico VARCHAR(15),
    @Email_tecnico VARCHAR(50)
AS
BEGIN
    -- Verificar si el técnico ya existe
    IF NOT EXISTS (SELECT 1 FROM tb_tecnico WHERE cedula_tecnico = @Cedula)
    BEGIN
        -- Si no existe, insertar el nuevo técnico
        INSERT INTO tb_tecnico (cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico)
        VALUES (@Cedula, @Nombre_tecnico, @Telefono_tecnico, @Email_tecnico);
    END
    -- Retornar el ID del técnico (si existe o si se acaba de insertar)
    SELECT id_tecnico FROM tb_tecnico WHERE cedula_tecnico = @Cedula;
END;


GO
CREATE PROCEDURE SP_ASIGNAR_EQUIPO_A_TECNICO
    @Codigo_Tecnico INT,
    @Codigo_Equipo INT,
    @Cedula_tecnico VARCHAR(10),
    @IMEI VARCHAR(15),
    @Cedula_Cliente VARCHAR(10),
    @Descripcion_Equipo VARCHAR(100)
AS
BEGIN
    -- Manejar excepciones
    BEGIN TRY
        -- Verificar si el equipo ya está asignado a este técnico
        IF NOT EXISTS (SELECT 1 
                       FROM tb_tecnico_equipo 
                       WHERE cedula_tecnico = @Cedula_tecnico AND imei_celular = @IMEI)
        BEGIN
            -- Asignar equipo al técnico
            INSERT INTO tb_tecnico_equipo 
                (cedula_tecnico, imei_celular, id_tecnico, id_equipo, descripcion_equipo, estado, fecha_ingreso, id_cliente)
            VALUES 
                (@Cedula_tecnico, @IMEI, @Codigo_Tecnico, @Codigo_Equipo, @Descripcion_Equipo, 'En revisión', GETDATE(), @Cedula_Cliente);
        END
        ELSE
        BEGIN
            -- Mensaje en caso de duplicado
            PRINT 'El equipo ya está asignado a este técnico.';
        END
    END TRY
    BEGIN CATCH
        -- Captura y manejo de errores
        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO


CREATE PROCEDURE SP_INSERT_CLIENTE
    @Cedula VARCHAR(10),
	@Nombre VARCHAR(50),
    @Telefono VARCHAR(15),
    @Email VARCHAR(50)
AS
BEGIN
    INSERT INTO tb_cliente (cedula_cliente, nombre_cliente, telefono_cliente, email_cliente)
    VALUES (@Cedula, @Nombre, @Telefono, @Email);
END;
GO
CREATE PROCEDURE SP_UPDATE_ESTADO_EQUIPO
    @Codigo_equipo INT,
    @IMEI VARCHAR(15),
    @nuevo_estado VARCHAR(20)
AS
BEGIN
    UPDATE tb_equipo_Movil
    SET estado = @nuevo_estado
    WHERE imei_celular = @IMEI;
END;
GO
CREATE PROCEDURE SP_ELIMINAR_EQUIPO
    @IMEI VARCHAR(20)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Eliminar registros relacionados en tb_reparacion_repuestos
        DELETE FROM tb_reparacion_repuestos
        WHERE id_equipo IN (
            SELECT id_equipo
            FROM tb_equipo_Movil
            WHERE imei_celular = @IMEI
        );

        -- Eliminar registros relacionados en tb_reparacion_tecnico
        DELETE FROM tb_reparacion_tecnico
        WHERE id_equipo IN (
            SELECT id_equipo
            FROM tb_equipo_Movil
            WHERE imei_celular = @IMEI
        );

        -- Eliminar registros relacionados en tb_factura
        DELETE FROM tb_factura
        WHERE id_reparacion IN (
            SELECT id_reparacion
            FROM tb_reparacion
            WHERE imei_celular = @IMEI
        );

        -- Eliminar registros relacionados en tb_reparacion
        DELETE FROM tb_reparacion
        WHERE imei_celular = @IMEI;

        -- Eliminar registros relacionados en tb_tecnico_equipo
        DELETE FROM tb_tecnico_equipo
        WHERE imei_celular = @IMEI;

        -- Eliminar el equipo móvil
        DELETE FROM tb_equipo_Movil
        WHERE imei_celular = @IMEI;

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
CREATE PROCEDURE SP_ELIMINAR_REPARACION
    @Codigo_reparacion INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE rr
        FROM tb_reparacion_repuestos rr
        INNER JOIN tb_reparacion r ON rr.id_equipo = r.id_equipo
        WHERE r.id_reparacion = @Codigo_reparacion;

        DELETE FROM tb_factura
        WHERE id_reparacion = @Codigo_reparacion;

        DELETE rt
        FROM tb_reparacion_tecnico rt
        INNER JOIN tb_reparacion r ON rt.id_equipo = r.id_equipo
        WHERE r.id_reparacion = @Codigo_reparacion;

        DELETE FROM tb_reparacion
        WHERE id_reparacion = @Codigo_reparacion;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
CREATE PROCEDURE SP_DELETE_CLIENTE
    @Cedula_cliente VARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Eliminar registros relacionados en tb_reparacion_repuestos
        DELETE FROM tb_reparacion_repuestos
        WHERE id_equipo IN (
            SELECT id_equipo
            FROM tb_equipo_Movil
            WHERE cedula_cliente = @Cedula_cliente
        );

        -- Eliminar registros relacionados en tb_reparacion_tecnico
        DELETE FROM tb_reparacion_tecnico
        WHERE id_equipo IN (
            SELECT id_equipo
            FROM tb_equipo_Movil
            WHERE cedula_cliente = @Cedula_cliente
        );

        -- Eliminar registros relacionados en tb_factura
        DELETE FROM tb_factura
        WHERE id_reparacion IN (
            SELECT id_reparacion
            FROM tb_reparacion
            WHERE imei_celular IN (
                SELECT imei_celular
                FROM tb_equipo_Movil
                WHERE cedula_cliente = @Cedula_cliente
            )
        );

        -- Eliminar registros relacionados en tb_reparacion
        DELETE FROM tb_reparacion
        WHERE imei_celular IN (
            SELECT imei_celular
            FROM tb_equipo_Movil
            WHERE cedula_cliente = @Cedula_cliente
        );

        -- Eliminar registros relacionados en tb_tecnico_equipo
        DELETE FROM tb_tecnico_equipo
        WHERE imei_celular IN (
            SELECT imei_celular
            FROM tb_equipo_Movil
            WHERE cedula_cliente = @Cedula_cliente
        );

        -- Eliminar los equipos móviles relacionados
        DELETE FROM tb_equipo_Movil
        WHERE cedula_cliente = @Cedula_cliente;

        -- Finalmente, eliminar el cliente
        DELETE FROM tb_cliente
        WHERE cedula_cliente = @Cedula_cliente;

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;

GO
CREATE PROCEDURE SP_UPDATE_REPARACION
    @Codigo_reparacion INT,
    @nueva_descripcion VARCHAR(255) = NULL, -- Parámetro opcional
    @nuevo_costo DECIMAL(10,2) = NULL, -- Parámetro opcional
    @nuevo_estado VARCHAR(20),
    @nueva_fecha_ingreso DATETIME,
    @nueva_fecha_entrega VARCHAR(10),
    @nuevos_tecnicos NVARCHAR(MAX) -- Lista de técnicos en formato JSON o separados por comas
AS
BEGIN
    BEGIN TRY
        -- Inicio de transacción
        BEGIN TRANSACTION;

        DECLARE @IMEI VARCHAR(15);
        SELECT @IMEI = imei_celular
        FROM tb_reparacion
        WHERE id_reparacion = @Codigo_reparacion;

        -- Actualizar campos opcionales
        IF @nueva_descripcion IS NOT NULL
        BEGIN
            UPDATE tb_reparacion
            SET descripcion_reparacion = @nueva_descripcion
            WHERE id_reparacion = @Codigo_reparacion;
        END;

        IF @nuevo_costo IS NOT NULL
        BEGIN
            UPDATE tb_reparacion
            SET costo = @nuevo_costo
            WHERE id_reparacion = @Codigo_reparacion;
        END;

        -- Actualizar campos obligatorios
        UPDATE tb_reparacion
        SET estado = @nuevo_estado,
            fecha_ingreso = @nueva_fecha_ingreso,
            fecha_entrega = @nueva_fecha_entrega
        WHERE id_reparacion = @Codigo_reparacion;

        UPDATE tb_equipo_Movil
        SET estado = @nuevo_estado,
            fecha_ingreso = @nueva_fecha_ingreso
        WHERE imei_celular = @IMEI;

        -- Actualizar la lista de técnicos
        IF @nuevos_tecnicos IS NOT NULL
        BEGIN
            -- Eliminar asignaciones anteriores de técnicos para esta reparación
            DELETE FROM tb_reparacion_tecnico
            WHERE id_equipo = (SELECT id_equipo FROM tb_reparacion WHERE id_reparacion = @Codigo_reparacion);

            -- Insertar las nuevas asignaciones de técnicos
            DECLARE @TecnicoId INT;
            DECLARE @TecnicosCursor CURSOR;

            -- Convertir la lista de IDs (separada por comas) en un cursor
            SET @TecnicosCursor = CURSOR FOR
            SELECT value FROM STRING_SPLIT(@nuevos_tecnicos, ',');

            OPEN @TecnicosCursor;

            FETCH NEXT FROM @TecnicosCursor INTO @TecnicoId;

            WHILE @@FETCH_STATUS = 0
            BEGIN
                -- Insertar cada técnico asociado a la reparación
                INSERT INTO tb_reparacion_tecnico (id_equipo, id_tecnico)
                VALUES (
                    (SELECT id_equipo FROM tb_reparacion WHERE id_reparacion = @Codigo_reparacion),
                    @TecnicoId
                );

                FETCH NEXT FROM @TecnicosCursor INTO @TecnicoId;
            END;

            CLOSE @TecnicosCursor;
            DEALLOCATE @TecnicosCursor;
        END;

        -- Confirmar transacción
        COMMIT TRANSACTION;

        PRINT 'Reparación actualizada correctamente con los técnicos asignados.';
    END TRY
    BEGIN CATCH
        -- Revertir transacción en caso de error
        ROLLBACK TRANSACTION;

        PRINT 'Error al actualizar la reparación. Transacción revertida.';
        THROW;
    END CATCH;
END;
GO
CREATE PROCEDURE SP_GET_EQUIPOS_MOVILES
AS
BEGIN
    SELECT * FROM tb_equipo_Movil;
END;

GO
CREATE PROCEDURE SP_GET_EQUIPOS
AS
BEGIN
    SELECT * FROM tb_equipo_Movil;
END;
GO
CREATE PROCEDURE SP_GET_TODAS_FACTURAS
AS
BEGIN
    -- Obtenemos todas las facturas con los técnicos asignados
    SELECT f.id_factura, f.id_cliente, f.cedula_cliente, f.nombre_cliente, f.telefono_cliente, f.email_cliente,
           f.id_equipo, f.imei_celular, f.descripcion_equipo, f.estado, f.fecha_ingreso,
           f.id_reparacion, f.descripcion_reparacion, f.costo, f.fecha_entrega, f.tecnicos
    FROM tb_factura f;
END;
GO
CREATE PROCEDURE SP_GET_REPARACIONES
AS
BEGIN
    SELECT 
        r.id_reparacion,
        r.cedula_cliente,
        r.imei_celular,
        r.descripcion_reparacion,
        r.costo,
        r.estado AS estado_reparacion,
        r.fecha_ingreso,
        r.fecha_entrega,
        r.id_equipo,
        r.id_cliente,
        -- Datos del cliente
        c.nombre_cliente,
        c.telefono_cliente,
        c.email_cliente,
        -- Datos de los técnicos asociados
        t.id_tecnico,
        t.cedula_tecnico,
        t.nombre_tecnico,
        t.telefono_tecnico,
        t.email_tecnico
    FROM 
        tb_reparacion r
    LEFT JOIN 
        tb_reparacion_tecnico rt ON r.id_equipo = r.id_equipo
    LEFT JOIN 
        tb_tecnico t ON rt.id_tecnico = t.id_tecnico
    LEFT JOIN 
        tb_cliente c ON r.cedula_cliente = c.cedula_cliente;
END;
GO
CREATE PROCEDURE SP_GET_TECNICOS
AS
BEGIN
    SELECT * FROM tb_tecnico;
END;

GO
CREATE PROCEDURE SP_GET_SERVICIOS
AS
BEGIN
    SELECT * FROM tb_servicios;
END;

GO
CREATE PROCEDURE SP_GET_REPUESTOS
AS
BEGIN
    SELECT * FROM tb_repuestos;
END;

GO
CREATE PROCEDURE SP_OBTENER_ULTIMO_ID_REPARACION
AS
BEGIN
    SELECT MAX(id_reparacion) AS id_reparacion FROM tb_reparacion;
END;

GO
CREATE PROCEDURE SP_ACTUALIZAR_REPUESTOS
    @id_equipo INT,
    @id_repuesto INT = NULL,
    @nueva_cantidad INT = NULL,
    @nuevo_costo_individual DECIMAL(10,2) = NULL,
    @nueva_descripcion NVARCHAR(255) = NULL
AS
BEGIN
    -- Procedimiento para actualizar repuestos asociados a un equipo
    -- La columna costo_total_repuesto se calcula automáticamente
    
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Si se especifica un repuesto específico, actualizar solo ese
        IF @id_repuesto IS NOT NULL
        BEGIN
            -- Verificar que el repuesto esté asociado al equipo
            IF EXISTS (SELECT 1 FROM tb_reparacion_repuestos 
                      WHERE id_equipo = @id_equipo AND id_repuesto = @id_repuesto)
            BEGIN
                -- Actualizar solo los campos que no son NULL
                UPDATE tb_repuestos 
                SET cantidad_repuesto = ISNULL(@nueva_cantidad, cantidad_repuesto),
                    costo_individual = ISNULL(@nuevo_costo_individual, costo_individual),
                    descripcion_repuesto = ISNULL(@nueva_descripcion, descripcion_repuesto)
                WHERE id_repuesto = @id_repuesto;
                
                PRINT 'Repuesto actualizado exitosamente.';
            END
            ELSE
            BEGIN
                PRINT 'El repuesto no está asociado a este equipo.';
            END
        END
        ELSE
        BEGIN
            -- Si no se especifica repuesto, mostrar información de los repuestos del equipo
            SELECT r.id_repuesto, r.descripcion_repuesto, r.cantidad_repuesto, 
                   r.costo_individual, r.costo_total_repuesto
            FROM tb_repuestos r
            INNER JOIN tb_reparacion_repuestos rr ON r.id_repuesto = rr.id_repuesto
            WHERE rr.id_equipo = @id_equipo;
        END
         END TRY
     BEGIN CATCH
         PRINT 'Error al actualizar repuestos: ' + ERROR_MESSAGE();
         THROW;
     END CATCH
END;

-- Procedimiento alternativo simple para compatibilidad hacia atrás
GO
CREATE PROCEDURE SP_RECALCULAR_REPUESTOS
    @id_equipo INT
AS
BEGIN
    -- Este procedimiento no hace nada especial porque las columnas calculadas
    -- se actualizan automáticamente en SQL Server
    -- Solo devuelve información de los repuestos del equipo
    
    SELECT r.id_repuesto, r.descripcion_repuesto, r.cantidad_repuesto, 
           r.costo_individual, r.costo_total_repuesto
    FROM tb_repuestos r
    INNER JOIN tb_reparacion_repuestos rr ON r.id_repuesto = rr.id_repuesto
    WHERE rr.id_equipo = @id_equipo;
    
    PRINT 'Información de repuestos consultada para equipo: ' + CAST(@id_equipo AS VARCHAR(10));
END;
GO

CREATE PROCEDURE SP_GET_CLIENTES
AS
BEGIN
    SELECT * FROM tb_cliente;
END;
GO
CREATE PROCEDURE SP_UPDATE_CLIENTE
    @Cedula_cliente VARCHAR(10),
    @Nombre_cliente VARCHAR(50),
    @Telefono_cliente VARCHAR(15),
    @Email_cliente VARCHAR(50)
AS
BEGIN
    UPDATE tb_cliente
    SET nombre_cliente = @Nombre_cliente,
        telefono_cliente = @Telefono_cliente,
        email_cliente = @Email_cliente
    WHERE cedula_cliente = @Cedula_cliente;
END;
GO
CREATE PROCEDURE SP_OBTENER_EQUIPO_ESTADO_CLIENTE
    @Cedula_Cliente VARCHAR(10),
    @Estado VARCHAR(20)
AS
BEGIN
    SELECT 
        em.id_equipo,
        em.imei_celular,
        em.descripcion_equipo,
        em.estado,
        em.fecha_ingreso
    FROM tb_equipo_Movil em
    WHERE em.cedula_cliente = @Cedula_Cliente AND em.estado = @Estado;
END;
GO


CREATE PROCEDURE SP_GET_ESTADO_EQUIPO_ESPECIFICO
    @Estado VARCHAR(20),
	@Cedula_cliente VARCHAR(20)
AS
BEGIN
    SELECT id_equipo, imei_celular, cedula_cliente, descripcion_equipo, estado, fecha_ingreso
    FROM tb_equipo_Movil
    WHERE cedula_cliente = @Cedula_cliente AND estado = @Estado;
END;
GO
CREATE PROCEDURE SP_GET_EQUIPO_MOVIL_CLIENTE
    @Cedula_cliente VARCHAR(10)
AS
BEGIN
    SELECT id_equipo, imei_celular, descripcion_equipo, estado, fecha_ingreso
    FROM tb_equipo_Movil
    WHERE cedula_cliente = @Cedula_cliente;
END;

GO
CREATE PROCEDURE SP_UPDATE_TECNICO
    @Cedula_tecnico VARCHAR(10),
    @Nuevo_nombre_tecnico VARCHAR(50) = NULL, 
    @Nuevo_telefono_tecnico VARCHAR(15) = NULL, 
    @Nuevo_email_tecnico VARCHAR(50) = NULL 
AS
BEGIN
    IF @Nuevo_nombre_tecnico IS NOT NULL
    BEGIN
        UPDATE tb_tecnico
        SET nombre_tecnico = @Nuevo_nombre_tecnico
        WHERE cedula_tecnico = @Cedula_tecnico;
    END

    IF @Nuevo_telefono_tecnico IS NOT NULL
    BEGIN
        UPDATE tb_tecnico
        SET telefono_tecnico = @Nuevo_telefono_tecnico
        WHERE cedula_tecnico = @Cedula_tecnico;
    END

    IF @Nuevo_email_tecnico IS NOT NULL
    BEGIN
        UPDATE tb_tecnico
        SET email_tecnico = @Nuevo_email_tecnico
        WHERE cedula_tecnico = @Cedula_tecnico;
    END
END;
GO
CREATE PROCEDURE SP_DELETE_TECNICO
    @Cedula_tecnico VARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Declarar el ID del técnico
        DECLARE @Id_tecnico INT;

        -- Obtener el ID del técnico basado en la cédula
        SELECT @Id_tecnico = id_tecnico
        FROM tb_tecnico
        WHERE cedula_tecnico = @Cedula_tecnico;

        -- Verificar si el técnico existe
        IF @Id_tecnico IS NULL
        BEGIN
            PRINT 'El técnico no existe.';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Eliminar relaciones del técnico en tb_reparacion_tecnico
        DELETE FROM tb_reparacion_tecnico
        WHERE id_tecnico = @Id_tecnico;

        -- Eliminar relaciones del técnico en tb_tecnico_equipo
        DELETE FROM tb_tecnico_equipo
        WHERE cedula_tecnico = @Cedula_tecnico;

        -- Eliminar facturas relacionadas con el técnico
        DELETE FROM tb_factura
        WHERE cedula_tecnico = @Cedula_tecnico;

        -- Eliminar al técnico de la tabla tb_tecnico
        DELETE FROM tb_tecnico
        WHERE id_tecnico = @Id_tecnico;

        -- Confirmar la transacción
        COMMIT TRANSACTION;

        PRINT 'Técnico y sus dependencias eliminados correctamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;

GO

CREATE PROCEDURE SP_GET_CEDULAS_TECNICO
AS
BEGIN
    SELECT cedula_tecnico
    FROM tb_tecnico;
END;
GO

CREATE PROCEDURE SP_GET_TECNICO_POR_CEDULA
    @Cedula VARCHAR(10)
AS
BEGIN
    SELECT id_tecnico, cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico
    FROM tb_tecnico
    WHERE cedula_tecnico = @Cedula;
END;
GO
CREATE PROCEDURE SP_GET_CEDULAS_CLIENTE
AS
BEGIN
    SELECT cedula_cliente
    FROM tb_cliente;
END;
GO
CREATE PROCEDURE SP_GET_CLIENTE_POR_CEDULA
    @Cedula VARCHAR(10)
AS
BEGIN
    SELECT id_cliente, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente
    FROM tb_cliente
    WHERE cedula_cliente = @Cedula;
END;
GO
CREATE PROCEDURE SP_GET_CEDULAS_PERSONA 
    @Cedula VARCHAR(10) = NULL
AS
BEGIN
    IF @Cedula IS NULL
    BEGIN
        SELECT cedula_cliente AS cedula FROM tb_cliente
        UNION
        SELECT cedula_tecnico AS cedula FROM tb_tecnico;
    END
    ELSE
    BEGIN
        SELECT 1
        WHERE EXISTS (
            SELECT 1 FROM tb_cliente WHERE cedula_cliente = @Cedula
            UNION
            SELECT 1 FROM tb_tecnico WHERE cedula_tecnico = @Cedula
        );
    END
END;
GO
CREATE PROCEDURE SP_GET_DATOS_PERSONALES_TECNICO
    @Cedula_Tecnico VARCHAR(10)
AS
BEGIN
    SELECT id_tecnico, cedula_tecnico, nombre_tecnico, telefono_tecnico, email_tecnico
    FROM tb_tecnico
    WHERE cedula_tecnico = @Cedula_Tecnico;
END;
GO
CREATE PROCEDURE SP_GET_DATOS_PERSONALES_CLIENTE
    @Cedula_Cliente VARCHAR(10)
AS
BEGIN
    SELECT id_cliente, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente
    FROM tb_cliente
    WHERE cedula_cliente = @Cedula_Cliente;
END;

GO
CREATE PROCEDURE SP_OBTENER_EQUIPOS_ASIGNADOS
    @Cedula_Tecnico VARCHAR(10)
AS
BEGIN
    SELECT 
        tec.cedula_tecnico, 
        eq.descripcion_equipo, 
        eq.imei_celular,
        eq.estado,
        eq.fecha_ingreso,
        eq.cedula_cliente
    FROM tb_tecnico_equipo tec
    INNER JOIN tb_equipo_Movil eq ON tec.id_equipo = eq.id_equipo
    WHERE tec.cedula_tecnico = @Cedula_Tecnico;
END;
GO
CREATE PROCEDURE SP_INSERTAR_REPARACION
    @Cedula_Cliente VARCHAR(10),
    @IMEI_Celular VARCHAR(15),
    @Descripcion_Reparacion VARCHAR(255),
    @Costo DECIMAL(10, 2),
    @Estado VARCHAR(50),
    @Tecnicos NVARCHAR(MAX)
AS
BEGIN
    DECLARE @ID_Reparacion INT;

    -- Insertar la reparación
    INSERT INTO tb_reparacion (cedula_cliente, imei_celular, descripcion_reparacion, costo, estado, fecha_ingreso)
    VALUES (@Cedula_Cliente, @IMEI_Celular, @Descripcion_Reparacion, @Costo, @Estado, GETDATE());

    -- Obtener el ID de la reparación recién insertada
    SET @ID_Reparacion = SCOPE_IDENTITY();

    -- Insertar los técnicos asociados
    DECLARE @Tecnico VARCHAR(10);
    DECLARE TecnicoCursor CURSOR FOR
    SELECT value FROM STRING_SPLIT(@Tecnicos, ',');

    OPEN TecnicoCursor;
    FETCH NEXT FROM TecnicoCursor INTO @Tecnico;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Validar si el técnico existe
        IF NOT EXISTS (SELECT 1 FROM tb_tecnico WHERE cedula_tecnico = @Tecnico)
        BEGIN
            PRINT 'El técnico con cédula ' + @Tecnico + ' no existe. Proceso abortado.';
            CLOSE TecnicoCursor;
            DEALLOCATE TecnicoCursor;
            RETURN;
        END

        -- Insertar la relación si el técnico existe
        INSERT INTO tb_reparacion_tecnico (id_equipo, id_tecnico)
        SELECT @ID_Reparacion, id_tecnico
        FROM tb_tecnico
        WHERE cedula_tecnico = @Tecnico;
        
        FETCH NEXT FROM TecnicoCursor INTO @Tecnico;
    END

    CLOSE TecnicoCursor;
    DEALLOCATE TecnicoCursor;
END;
GO
CREATE PROCEDURE SP_OBTENER_TECNICOS_REPARACION_PAGINADO
    @Id_Equipo INT,
    @Pagina INT,
    @TecnicosPorPagina INT
AS
BEGIN
    DECLARE @Inicio INT;
    SET @Inicio = (@Pagina - 1) * @TecnicosPorPagina;

    -- Selecciona los técnicos asignados a una reparación con paginación
    SELECT r.id_equipo,  -- Cambio aquí para mostrar el id_equipo
           r.descripcion_reparacion, 
           r.estado, 
           t.id_tecnico,   
           t.cedula_tecnico, 
           t.nombre_tecnico,
           t.telefono_tecnico,
           t.email_tecnico
    FROM tb_reparacion r
    INNER JOIN tb_reparacion_tecnico rt ON r.id_equipo = rt.id_equipo  
    INNER JOIN tb_tecnico t ON rt.id_tecnico = t.id_tecnico
    WHERE r.id_equipo = @Id_Equipo
    ORDER BY t.id_tecnico  -- Puedes ordenar por cualquier campo que sea adecuado
    OFFSET @Inicio ROWS 
    FETCH NEXT @TecnicosPorPagina ROWS ONLY;
END;
GO


CREATE PROCEDURE SP_ASIGNAR_TECNICOS_A_REPARACION
    @Id_Equipo INT,
    @Tecnicos NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @TecnicoId INT;
        DECLARE TecnicoCursor CURSOR FOR
        SELECT value FROM STRING_SPLIT(@Tecnicos, ',');

        OPEN TecnicoCursor;
        FETCH NEXT FROM TecnicoCursor INTO @TecnicoId;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Validar que el técnico no esté eliminado
            IF EXISTS (SELECT 1 FROM tb_tecnico WHERE id_tecnico = @TecnicoId)
            BEGIN
                -- Insertar solo si no existe la relación
                IF NOT EXISTS (
                    SELECT 1 
                    FROM tb_reparacion_tecnico 
                    WHERE id_equipo = @Id_Equipo AND id_tecnico = @TecnicoId
                )
                BEGIN
                    INSERT INTO tb_reparacion_tecnico (id_equipo, id_tecnico)
                    VALUES (@Id_Equipo, @TecnicoId);
                END
            END

            FETCH NEXT FROM TecnicoCursor INTO @TecnicoId;
        END

        CLOSE TecnicoCursor;
        DEALLOCATE TecnicoCursor;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error al asignar técnicos: ' + ERROR_MESSAGE();
    END CATCH;
END;

GO
CREATE PROCEDURE SP_INSERT_FACTURA
    @cedula_cliente VARCHAR(10),
    @id_equipo INT
AS
BEGIN
    DECLARE 
        @id_cliente INT,
        @nombre_cliente VARCHAR(50),
        @telefono_cliente VARCHAR(15),
        @email_cliente VARCHAR(50),
        @id_tecnico INT,
        @cedula_tecnico VARCHAR(10),
        @nombre_tecnico VARCHAR(50),
        @telefono_tecnico VARCHAR(15),
        @email_tecnico VARCHAR(50),
        @imei_celular VARCHAR(15),
        @descripcion_equipo VARCHAR(100),
        @estado VARCHAR(20),
        @fecha_ingreso DATETIME,
        @descripcion_reparacion VARCHAR(255),
        @costo DECIMAL(10,2),
        @fecha_entrega VARCHAR(10),
        @Tecnicos NVARCHAR(MAX),
        @id_reparacion INT;  -- Variable para almacenar el id de la reparación

    -- Obtener datos del cliente
    SELECT 
        @id_cliente = id_cliente,
        @nombre_cliente = nombre_cliente,
        @telefono_cliente = telefono_cliente,
        @email_cliente = email_cliente
    FROM tb_cliente
    WHERE cedula_cliente = @cedula_cliente;

    -- Obtener datos del equipo
    SELECT 
        @imei_celular = imei_celular,
        @descripcion_equipo = descripcion_equipo
    FROM tb_equipo_Movil
    WHERE id_equipo = @id_equipo;

    -- Obtener datos de la reparación, asociada al equipo
    SELECT 
        @id_reparacion = id_reparacion,  -- Asignamos id_reparacion desde la tabla de reparaciones
        @descripcion_reparacion = descripcion_reparacion,
        @estado = estado,
        @fecha_ingreso = fecha_ingreso,
        @fecha_entrega = fecha_entrega,
        @costo = costo
    FROM tb_reparacion
    WHERE id_equipo = @id_equipo;

    -- Obtener la lista de técnicos asociados a la reparación
    SET @Tecnicos = '';
    DECLARE TecnicoCursor CURSOR FOR
       SELECT t.cedula_tecnico, t.nombre_tecnico
        FROM tb_reparacion_tecnico rt
        INNER JOIN tb_tecnico t ON rt.id_tecnico = t.id_tecnico
        WHERE rt.id_equipo = @id_equipo;

    OPEN TecnicoCursor;
    FETCH NEXT FROM TecnicoCursor INTO @cedula_tecnico, @nombre_tecnico;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Validar si el técnico existe
        IF NOT EXISTS (SELECT 1 FROM tb_tecnico WHERE cedula_tecnico = @cedula_tecnico)
        BEGIN
            PRINT 'El técnico con cédula ' + @cedula_tecnico + ' no existe. Proceso abortado.';
            CLOSE TecnicoCursor;
            DEALLOCATE TecnicoCursor;
            RETURN;
        END

        -- Concatenar los datos del técnico si existe
        SET @Tecnicos = @Tecnicos + @cedula_tecnico + ' (' + @nombre_tecnico + '), '; 
        FETCH NEXT FROM TecnicoCursor INTO @cedula_tecnico, @nombre_tecnico;
    END

    CLOSE TecnicoCursor;
    DEALLOCATE TecnicoCursor;

    -- Eliminar la última coma y espacio
    SET @Tecnicos = RTRIM(LTRIM(SUBSTRING(@Tecnicos, 1, LEN(@Tecnicos) - 2)));

    -- Insertar en la tabla factura
    INSERT INTO tb_factura (
        id_cliente, cedula_cliente, nombre_cliente, telefono_cliente, email_cliente,
        id_equipo, imei_celular, descripcion_equipo, estado, fecha_ingreso,
        descripcion_reparacion, costo, fecha_entrega, tecnicos, id_reparacion
    )
    VALUES (
        @id_cliente, @cedula_cliente, @nombre_cliente, @telefono_cliente, @email_cliente,
        @id_equipo, @imei_celular, @descripcion_equipo, @estado, @fecha_ingreso,
        @descripcion_reparacion, @costo, @fecha_entrega, @Tecnicos, @id_reparacion
    );
END;
GO
CREATE PROCEDURE SP_GET_FACTURAS
    @Cedula_Cliente VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM tb_factura WHERE cedula_cliente = @Cedula_Cliente)
    BEGIN
        SELECT f.id_factura, f.id_cliente, f.cedula_cliente, f.nombre_cliente, f.telefono_cliente, f.email_cliente,
               f.id_equipo, f.imei_celular, f.descripcion_equipo, f.estado, f.fecha_ingreso,
               f.id_reparacion, f.descripcion_reparacion, f.costo, f.fecha_entrega, f.tecnicos
        FROM tb_factura f
        WHERE f.cedula_cliente = @Cedula_Cliente;
    END
    ELSE
    BEGIN
        RAISERROR ('No hay facturas asociadas a esta cédula.', 16, 1);
    END
END;
GO

CREATE PROCEDURE SP_GET_FACTURAS_POR_CEDULA_CLIENTE
    @cedulaCliente VARCHAR(20),
    @pagina INT,
    @facturasPorPagina INT
AS
BEGIN
    DECLARE @inicio INT
    SET @inicio = (@pagina - 1) * @facturasPorPagina;

    IF EXISTS (SELECT 1 FROM tb_factura WHERE cedula_cliente = @cedulaCliente)
    BEGIN
        SELECT f.id_factura, f.id_cliente, f.cedula_cliente, f.nombre_cliente, f.telefono_cliente, f.email_cliente,
               f.id_equipo, f.imei_celular, f.descripcion_equipo, f.estado, f.fecha_ingreso,
               f.id_reparacion, f.descripcion_reparacion, f.costo, f.fecha_entrega, f.tecnicos
        FROM tb_factura f
        WHERE f.cedula_cliente = @cedulaCliente
        ORDER BY f.id_factura 
        OFFSET @inicio ROWS 
        FETCH NEXT @facturasPorPagina ROWS ONLY;
    END
    ELSE
    BEGIN
        RAISERROR ('No hay facturas asociadas a esta cédula.', 16, 1);
    END
END;
GO
CREATE PROCEDURE SP_EXISTE_FACTURA
    @id_reparacion INT
AS
BEGIN
    -- Verifica si existe una factura para el id_reparacion
    IF EXISTS (SELECT 1 FROM tb_factura WHERE id_reparacion = @id_reparacion)
    BEGIN
        -- Si existe, retorna 1
        SELECT 1 AS ExisteFactura;
    END
    ELSE
    BEGIN
        -- Si no existe, retorna 0
        SELECT 0 AS ExisteFactura;
    END
END
GO
CREATE PROCEDURE SP_UPDATE_FACTURA
    @id_factura INT,
    @cedula_cliente NVARCHAR(10),
    @nombre_cliente NVARCHAR(50),
    @telefono_cliente NVARCHAR(15),
    @email_cliente NVARCHAR(50),
    @imei_celular NVARCHAR(15),
    @descripcion_equipo NVARCHAR(100),
    @estado NVARCHAR(20),
    @descripcion_reparacion NVARCHAR(255),
    @costo DECIMAL(10,2),
    @fecha_entrega NVARCHAR(10),
    @nuevos_tecnicos NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar si la factura ya existe
        IF EXISTS (SELECT 1 FROM tb_factura WHERE id_factura = @id_factura)
        BEGIN
            -- Actualizar los campos de la factura existente
            UPDATE tb_factura
            SET 
                cedula_cliente = @cedula_cliente,
                nombre_cliente = @nombre_cliente,
                telefono_cliente = @telefono_cliente,
                email_cliente = @email_cliente,
                imei_celular = @imei_celular,
                descripcion_equipo = @descripcion_equipo,
                estado = @estado,
                descripcion_reparacion = @descripcion_reparacion,
                costo = @costo,
                fecha_entrega = @fecha_entrega,
                tecnicos = @nuevos_tecnicos
            WHERE id_factura = @id_factura;

            -- Actualizar las tablas relacionadas
            UPDATE tb_reparacion
            SET 
                descripcion_reparacion = @descripcion_reparacion,
                costo = @costo,
                estado = @estado,
                fecha_entrega = @fecha_entrega
            WHERE imei_celular = @imei_celular;

            UPDATE tb_tecnico_equipo
            SET 
                descripcion_equipo = @descripcion_equipo,
                estado = @estado
            WHERE imei_celular = @imei_celular;

            -- Reasignar técnicos a la reparación
            DELETE FROM tb_reparacion_tecnico
            WHERE id_equipo = (SELECT id_equipo FROM tb_equipo_Movil WHERE imei_celular = @imei_celular);

            DECLARE @TecnicoId NVARCHAR(10);
            DECLARE TecnicoCursor CURSOR FOR
            SELECT value FROM STRING_SPLIT(@nuevos_tecnicos, ',');

            OPEN TecnicoCursor;
            FETCH NEXT FROM TecnicoCursor INTO @TecnicoId;

            WHILE @@FETCH_STATUS = 0
            BEGIN
                INSERT INTO tb_reparacion_tecnico (id_equipo, id_tecnico)
                VALUES ((SELECT id_equipo FROM tb_equipo_Movil WHERE imei_celular = @imei_celular), @TecnicoId);

                FETCH NEXT FROM TecnicoCursor INTO @TecnicoId;
            END

            CLOSE TecnicoCursor;
            DEALLOCATE TecnicoCursor;

            -- Verificar si hay técnicos asignados a la reparación
            DECLARE @TecnicosAsignados INT;
            SELECT @TecnicosAsignados = COUNT(*)
            FROM tb_reparacion_tecnico
            WHERE id_equipo = (SELECT id_equipo FROM tb_equipo_Movil WHERE imei_celular = @imei_celular);

            -- Si no hay técnicos asignados, eliminar reparación y factura
            IF @TecnicosAsignados = 0
            BEGIN
                DELETE FROM tb_factura WHERE id_factura = @id_factura;
                DELETE FROM tb_reparacion WHERE imei_celular = @imei_celular;
                DELETE FROM tb_reparacion_repuestos WHERE id_equipo = (SELECT id_equipo FROM tb_equipo_Movil WHERE imei_celular = @imei_celular);
            END
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;



GO
CREATE PROCEDURE SP_ELIMINAR_FACTURA
    @cedula_cliente VARCHAR(10)
AS
BEGIN
    -- Declarar las variables necesarias
    DECLARE @id_cliente INT;

    -- Obtener el id_cliente con base en la cédula del cliente
    SELECT @id_cliente = id_cliente
    FROM tb_cliente
    WHERE cedula_cliente = @cedula_cliente;

    -- Si se encuentra el cliente, proceder con la eliminación de la factura
    IF @id_cliente IS NOT NULL
    BEGIN
        DELETE FROM tb_factura
        WHERE id_cliente = @id_cliente;
        
        PRINT 'Factura eliminada exitosamente.';
    END
    ELSE
    BEGIN
        PRINT 'Cliente no encontrado.';
    END
END;
GO
CREATE PROCEDURE SP_VALIDAR_ID_EQUIPO
	@IdEquipo INT
AS
BEGIN
    SELECT 1
    FROM tb_equipo_Movil
    WHERE id_equipo = @IdEquipo
END

GO
EXEC SP_OBTENER_TECNICOS_REPARACION_PAGINADO @Id_Equipo = 1, @Pagina = 1, @TecnicosPorPagina = 10;
GO
EXEC SP_OBTENER_TECNICOS_REPARACION_PAGINADO @Id_Equipo = 2, @Pagina = 1, @TecnicosPorPagina = 10;
GO
EXEC SP_OBTENER_TECNICOS_REPARACION_PAGINADO @Id_Equipo = 3, @Pagina = 1, @TecnicosPorPagina = 10;
GO
CREATE PROCEDURE SP_GET_DETALLES_EQUIPO
    @IMEI VARCHAR(50)
AS
BEGIN
    SELECT 
        e.id_equipo, 
        e.imei_celular,
		e.cedula_cliente, 
        e.estado, 
		e.fecha_ingreso,
		e.descripcion_equipo
    FROM tb_equipo_Movil e
    WHERE e.imei_celular = @IMEI;
END;
GO
CREATE PROCEDURE SP_DESASIGNAR_TECNICO_REPARACION
    @IdEquipo INT,
    @IdTecnico INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Eliminar la relación entre el técnico y la reparación en tb_reparacion_tecnico
        DELETE FROM tb_reparacion_tecnico
        WHERE id_equipo = @IdEquipo AND id_tecnico = @IdTecnico;

        -- Eliminar la relación en tb_tecnico_equipo
        DELETE FROM tb_tecnico_equipo
        WHERE id_equipo = @IdEquipo AND id_tecnico = @IdTecnico;

        -- Verificar si ya no hay técnicos asignados a este equipo
        IF NOT EXISTS (SELECT 1 FROM tb_reparacion_tecnico WHERE id_equipo = @IdEquipo)
        BEGIN
            -- Eliminar registros dependientes en el orden correcto
            -- 1. Eliminar registros relacionados en tb_reparacion_repuestos
            DELETE FROM tb_reparacion_repuestos
            WHERE id_equipo = @IdEquipo;


            -- 3. Finalmente, eliminar la reparación
            DELETE FROM tb_reparacion
            WHERE id_equipo = @IdEquipo;
			            -- 2. Eliminar facturas relacionadas con la reparación
            DELETE FROM tb_factura
            WHERE id_reparacion IN (SELECT id_reparacion FROM tb_reparacion WHERE id_equipo = @IdEquipo);

        END

        -- Confirmar transacción
        COMMIT TRANSACTION;

        PRINT 'Técnico desasignado correctamente y reparación eliminada si es necesario.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción si ocurre un error
        ROLLBACK TRANSACTION;

        PRINT 'Error al desasignar el técnico. Transacción revertida.';
        THROW;
    END CATCH
END;



GO
CREATE PROCEDURE SP_OBTENER_TECNICOS_REPARACION
    @IdEquipo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        tt.id_tecnico,
        tt.cedula_tecnico,
        tt.nombre_tecnico,
        tt.telefono_tecnico,
        tt.email_tecnico
    FROM tb_tecnico tt
    INNER JOIN tb_reparacion_tecnico trt ON tt.id_tecnico = trt.id_tecnico
    WHERE trt.id_equipo = @IdEquipo;
END;
GO
CREATE PROCEDURE SP_EXISTE_REPARACION
    @IdEquipo INT,
    @Existe BIT OUTPUT
AS
BEGIN
    -- Verificar si existe una reparación asociada al equipo
    IF EXISTS (SELECT 1 FROM tb_reparacion WHERE id_equipo = @IdEquipo)
    BEGIN
        SET @Existe = 1;  -- Existe una reparación
    END
    ELSE
    BEGIN
        SET @Existe = 0;  -- No existe una reparación
    END
END;

GO
CREATE PROCEDURE SP_CALCULAR_COSTO_TOTAL_FACTURA
    @id_equipo INT
AS
BEGIN
    DECLARE @costo_total DECIMAL(10, 2);

    SELECT @costo_total = SUM(r.cantidad_repuesto * r.costo_individual)
    FROM tb_repuestos r
    INNER JOIN tb_reparacion_repuestos rr ON r.id_repuesto = rr.id_repuesto
    WHERE rr.id_equipo = @id_equipo;

    SELECT @costo_total; -- Retornar el costo total
END;

GO
CREATE PROCEDURE SP_GET_REPUESTOS_FACTURA  (
    @id_factura INT
)
AS
BEGIN
    SELECT r.id_repuesto, r.descripcion_repuesto, r.cantidad_repuesto, r.costo_individual, r.costo_total_repuesto
    FROM tb_repuestos r
    INNER JOIN tb_reparacion_repuestos rr ON r.id_repuesto = rr.id_repuesto
    INNER JOIN tb_factura f ON rr.id_equipo = f.id_equipo
    WHERE f.id_factura = @id_factura;
END;
GO
CREATE PROCEDURE SP_AGREGAR_REPUESTO (
    @descripcion_repuesto NVARCHAR(255),
    @cantidad_repuesto INT,
    @costo_individual DECIMAL(10,2),
    @id_equipo INT
)
AS
BEGIN
    -- Inserción de repuesto con ID de equipo
    INSERT INTO tb_repuestos (descripcion_repuesto, cantidad_repuesto, costo_individual)
    VALUES (@descripcion_repuesto, @cantidad_repuesto, @costo_individual);

    -- Luego de insertar, obtener el ID del repuesto insertado
    DECLARE @id_repuesto INT;
    SET @id_repuesto = SCOPE_IDENTITY(); -- Obtener el ID recién insertado

    -- Relacionar el repuesto con el equipo
    INSERT INTO tb_reparacion_repuestos (id_repuesto, id_equipo)
    VALUES (@id_repuesto, @id_equipo);
END;

GO
CREATE PROCEDURE SP_ELIMINAR_REPUESTO
    @id_repuesto INT
AS
BEGIN
    DELETE FROM tb_reparacion_repuestos WHERE id_repuesto = @id_repuesto;
    DELETE FROM tb_repuestos WHERE id_repuesto = @id_repuesto;
END;
GO
CREATE PROCEDURE SP_OBTENER_REPUESTOS_POR_EQUIPO
    @id_equipo INT
AS
BEGIN
    SELECT 
        r.id_repuesto,
        r.descripcion_repuesto,
        r.cantidad_repuesto,
        r.costo_individual,
        (r.cantidad_repuesto * r.costo_individual) AS costo_total
    FROM tb_repuestos r
    INNER JOIN tb_reparacion_repuestos rr ON r.id_repuesto = rr.id_repuesto
    WHERE rr.id_equipo = @id_equipo;
END;


GO
CREATE PROCEDURE SP_UPDATE_EQUIPO 
    @id_equipo INT, 
    @nuevo_imei_celular VARCHAR(15), 
    @nuevo_estado VARCHAR(20), 
    @nueva_fecha_ingreso DATETIME, 
    @nueva_descripcion VARCHAR(100)
AS 
BEGIN 
    -- Actualizar la tabla de equipos móviles
    UPDATE tb_equipo_Movil
    SET imei_celular = @nuevo_imei_celular,
        estado = @nuevo_estado,
        fecha_ingreso = @nueva_fecha_ingreso,
        descripcion_equipo = @nueva_descripcion
    WHERE id_equipo = @id_equipo;

    -- Actualizar la tabla de reparaciones
    UPDATE tb_reparacion
    SET imei_celular = @nuevo_imei_celular, 
        estado = @nuevo_estado,
        fecha_ingreso = @nueva_fecha_ingreso
    WHERE id_equipo = @id_equipo;
END;

-- Versión alternativa para la interfaz de móvil que usa parámetros diferentes
GO
CREATE PROCEDURE SP_UPDATE_EQUIPO_MOVIL
    @nueva_descripcion VARCHAR(100),
    @nuevo_estado VARCHAR(20),
    @nuevo_imei_celular VARCHAR(15),
    @nueva_fecha_ingreso DATETIME
AS 
BEGIN 
    UPDATE tb_equipo_Movil
    SET descripcion_equipo = @nueva_descripcion,
        estado = @nuevo_estado,
        fecha_ingreso = @nueva_fecha_ingreso
    WHERE imei_celular = @nuevo_imei_celular;
END;
GO
CREATE TABLE Usuarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(256) NOT NULL -- Almacenar contraseñas encriptadas
);
GO
CREATE PROCEDURE sp_InsertarUsuario
	@username NVARCHAR(50),
	@password NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE username = @username)
    BEGIN
        INSERT INTO Usuarios (username, password)
        VALUES (@username, @password); 
        RETURN 1; 
    END
    ELSE
    BEGIN
        RETURN 0; 
    END
END;
GO
CREATE PROCEDURE sp_ValidarUsuario
	@username NVARCHAR(50),
	@password NVARCHAR(50)
AS
BEGIN
    SELECT * 
    FROM Usuarios 
    WHERE username = @username AND password = @password;
END;
GO
CREATE PROCEDURE SP_EXISTE_USUARIO
	@username NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE username = @username)
    BEGIN
        RETURN 1; -- Usuario existe
    END
    ELSE
    BEGIN
        RETURN 0; -- Usuario no existe
    END
END;
GO
GO
EXEC sp_InsertarUsuario @username = 'leslie', @password = '22';
GO
EXEC sp_ValidarUsuario @username = 'leslie', @password = '22';

GO
SELECT * FROM Usuarios;
GO
SELECT * FROM tb_equipo_Movil;

-- ================================
-- CREACIÓN DE ROLES Y PERMISOS - SQL SERVER
-- ================================

-- Crear roles de base de datos
CREATE ROLE [db_administrador];
CREATE ROLE [db_usuario];

-- Asignar permisos al rol administrador (permisos completos)
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO [db_administrador];
GRANT EXECUTE ON SCHEMA::dbo TO [db_administrador];

-- Asignar permisos al rol usuario (solo lectura)
GRANT SELECT ON dbo.tb_cliente TO [db_usuario];
GRANT SELECT ON dbo.tb_tecnico TO [db_usuario];
GRANT SELECT ON dbo.tb_equipo_Movil TO [db_usuario];
GRANT SELECT ON dbo.tb_reparacion TO [db_usuario];
GRANT SELECT ON dbo.tb_tecnico_equipo TO [db_usuario];
GRANT SELECT ON dbo.tb_reparacion_tecnico TO [db_usuario];
GRANT SELECT ON dbo.tb_factura TO [db_usuario];
GRANT SELECT ON dbo.tb_repuestos TO [db_usuario];
GRANT SELECT ON dbo.tb_servicios TO [db_usuario];
GRANT SELECT ON dbo.tb_reparacion_repuestos TO [db_usuario];
GRANT SELECT ON dbo.Usuarios TO [db_usuario];

-- Permitir al usuario ejecutar procedimientos almacenados de consulta (solo SELECT)
GRANT EXECUTE ON dbo.SP_GET_CLIENTES TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_TECNICOS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_EQUIPOS_MOVILES TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_EQUIPOS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_SERVICIOS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_REPUESTOS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_REPARACIONES TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_TODAS_FACTURAS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_FACTURAS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_FACTURAS_POR_CEDULA_CLIENTE TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_CEDULAS_CLIENTE TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_CEDULAS_TECNICO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_CEDULAS_PERSONA TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_CLIENTE_POR_CEDULA TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_TECNICO_POR_CEDULA TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_DATOS_PERSONALES_CLIENTE TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_DATOS_PERSONALES_TECNICO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_EQUIPO_MOVIL_CLIENTE TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_ESTADO_EQUIPO_ESPECIFICO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_OBTENER_EQUIPO_ESTADO_CLIENTE TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_DETALLES_EQUIPO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_VALIDAR_ID_EQUIPO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_OBTENER_EQUIPOS_ASIGNADOS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_OBTENER_TECNICOS_REPARACION_PAGINADO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_OBTENER_TECNICOS_REPARACION TO [db_usuario];
GRANT EXECUTE ON dbo.SP_EXISTE_REPARACION TO [db_usuario];
GRANT EXECUTE ON dbo.SP_EXISTE_FACTURA TO [db_usuario];
GRANT EXECUTE ON dbo.SP_EXISTE_USUARIO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_GET_REPUESTOS_FACTURA TO [db_usuario];
GRANT EXECUTE ON dbo.SP_OBTENER_REPUESTOS_POR_EQUIPO TO [db_usuario];
GRANT EXECUTE ON dbo.SP_CALCULAR_COSTO_TOTAL_FACTURA TO [db_usuario];
GRANT EXECUTE ON dbo.SP_RECALCULAR_REPUESTOS TO [db_usuario];
GRANT EXECUTE ON dbo.SP_OBTENER_ULTIMO_ID_REPARACION TO [db_usuario];
GRANT EXECUTE ON dbo.sp_ValidarUsuario TO [db_usuario];

-- Crear logins de SQL Server
CREATE LOGIN [admin_reparaciones] WITH PASSWORD = 'AdminPass123!';
CREATE LOGIN [consulta_reparaciones] WITH PASSWORD = 'ConsultaPass123!';
CREATE LOGIN [app_reparaciones] WITH PASSWORD = 'AppPass123!';

-- Crear usuarios de base de datos y asignar roles
CREATE USER [admin_reparaciones] FOR LOGIN [admin_reparaciones];
ALTER ROLE [db_administrador] ADD MEMBER [admin_reparaciones];

CREATE USER [consulta_reparaciones] FOR LOGIN [consulta_reparaciones];
ALTER ROLE [db_usuario] ADD MEMBER [consulta_reparaciones];

CREATE USER [app_reparaciones] FOR LOGIN [app_reparaciones];
ALTER ROLE [db_administrador] ADD MEMBER [app_reparaciones];

-- Verificar roles y usuarios creados
SELECT 
    r.name AS RoleName,
    m.name AS MemberName
FROM sys.database_role_members rm
JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
WHERE r.name IN ('db_administrador', 'db_usuario');

-- Verificar logins creados
SELECT 
    name AS LoginName,
    type_desc AS LoginType,
    create_date AS CreateDate
FROM sys.server_principals
WHERE name IN ('admin_reparaciones', 'consulta_reparaciones', 'app_reparaciones');

-- Verificar usuarios de base de datos creados
SELECT 
    name AS UserName,
    type_desc AS UserType,
    create_date AS CreateDate
FROM sys.database_principals
WHERE name IN ('admin_reparaciones', 'consulta_reparaciones', 'app_reparaciones');

GO
