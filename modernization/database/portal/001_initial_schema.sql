USE [Essco_Portal];
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'Portal.Migraciones',N'U') IS NOT NULL
BEGIN
    IF EXISTS(SELECT 1 FROM Portal.Migraciones WHERE Version=1)
    BEGIN
        COMMIT;
        RETURN;
    END;
END;
IF SCHEMA_ID(N'Portal') IS NULL EXEC(N'CREATE SCHEMA Portal AUTHORIZATION dbo');
IF SCHEMA_ID(N'Identidad') IS NULL EXEC(N'CREATE SCHEMA Identidad AUTHORIZATION dbo');
IF SCHEMA_ID(N'Suscripciones') IS NULL EXEC(N'CREATE SCHEMA Suscripciones AUTHORIZATION dbo');
IF SCHEMA_ID(N'Auditoria') IS NULL EXEC(N'CREATE SCHEMA Auditoria AUTHORIZATION dbo');

CREATE TABLE Portal.Migraciones(Version int NOT NULL PRIMARY KEY, AplicadaUtc datetime2 NOT NULL DEFAULT SYSUTCDATETIME());
CREATE TABLE Portal.Organizaciones(
 Id uniqueidentifier NOT NULL PRIMARY KEY DEFAULT NEWID(),
 Nombre nvarchar(200) NOT NULL,
 Activa bit NOT NULL DEFAULT 1,
 CreadaUtc datetime2 NOT NULL DEFAULT SYSUTCDATETIME());
CREATE TABLE Identidad.Usuarios(
 Id uniqueidentifier NOT NULL PRIMARY KEY DEFAULT NEWID(),
 CorreoNormalizado nvarchar(254) NOT NULL UNIQUE,
 Nombre nvarchar(200) NOT NULL,
 PasswordHash nvarchar(512) NOT NULL,
 Activo bit NOT NULL DEFAULT 1,
 IntentosFallidos int NOT NULL DEFAULT 0 CHECK(IntentosFallidos>=0),
 BloqueadoHastaUtc datetime2 NULL,
 CreadoUtc datetime2 NOT NULL DEFAULT SYSUTCDATETIME());
CREATE TABLE Identidad.Membresias(
 OrganizacionId uniqueidentifier NOT NULL REFERENCES Portal.Organizaciones(Id),
 UsuarioId uniqueidentifier NOT NULL REFERENCES Identidad.Usuarios(Id),
 Rol varchar(20) NOT NULL CHECK(Rol IN ('Administrador','Miembro')),
 Activa bit NOT NULL DEFAULT 1,
 PRIMARY KEY(OrganizacionId,UsuarioId));
CREATE TABLE Portal.Aplicaciones(
 Codigo varchar(50) NOT NULL PRIMARY KEY,
 Nombre nvarchar(100) NOT NULL,
 Descripcion nvarchar(500) NOT NULL,
 Activa bit NOT NULL DEFAULT 1);
CREATE TABLE Portal.OrganizacionAplicaciones(
 OrganizacionId uniqueidentifier NOT NULL REFERENCES Portal.Organizaciones(Id),
 AplicacionCodigo varchar(50) NOT NULL REFERENCES Portal.Aplicaciones(Codigo),
 Habilitada bit NOT NULL DEFAULT 0,
 PRIMARY KEY(OrganizacionId,AplicacionCodigo));
CREATE TABLE Portal.Accesos(
 OrganizacionId uniqueidentifier NOT NULL,
 UsuarioId uniqueidentifier NOT NULL,
 AplicacionCodigo varchar(50) NOT NULL,
 PRIMARY KEY(OrganizacionId,UsuarioId,AplicacionCodigo),
 FOREIGN KEY(OrganizacionId,UsuarioId) REFERENCES Identidad.Membresias(OrganizacionId,UsuarioId),
 FOREIGN KEY(OrganizacionId,AplicacionCodigo) REFERENCES Portal.OrganizacionAplicaciones(OrganizacionId,AplicacionCodigo));
CREATE TABLE Suscripciones.Planes(
 AplicacionCodigo varchar(50) NOT NULL REFERENCES Portal.Aplicaciones(Codigo),
 Codigo varchar(50) NOT NULL,
 Nombre nvarchar(100) NOT NULL,
 PRIMARY KEY(AplicacionCodigo,Codigo));
CREATE TABLE Suscripciones.Contratos(
 Id uniqueidentifier NOT NULL PRIMARY KEY DEFAULT NEWID(),
 OrganizacionId uniqueidentifier NOT NULL,
 AplicacionCodigo varchar(50) NOT NULL,
 PlanCodigo varchar(50) NOT NULL,
 Estado varchar(20) NOT NULL CHECK(Estado IN ('Prueba','Activa','Suspendida','Cancelada')),
 VigenteDesdeUtc datetime2 NOT NULL,
 VigenteHastaUtc datetime2 NULL,
 FOREIGN KEY(OrganizacionId,AplicacionCodigo) REFERENCES Portal.OrganizacionAplicaciones(OrganizacionId,AplicacionCodigo),
 FOREIGN KEY(AplicacionCodigo,PlanCodigo) REFERENCES Suscripciones.Planes(AplicacionCodigo,Codigo),
 CHECK(VigenteHastaUtc IS NULL OR VigenteHastaUtc>=VigenteDesdeUtc));
CREATE TABLE Auditoria.Eventos(
 Id bigint IDENTITY PRIMARY KEY,
 OrganizacionId uniqueidentifier NULL REFERENCES Portal.Organizaciones(Id),
 UsuarioId uniqueidentifier NULL REFERENCES Identidad.Usuarios(Id),
 Accion varchar(100) NOT NULL,
 FechaUtc datetime2 NOT NULL DEFAULT SYSUTCDATETIME());
INSERT Portal.Aplicaciones(Codigo,Nombre,Descripcion)
 VALUES('syncro-cliente',N'Syncro Cliente',N'ERP: inventario, clientes, tesorería, planillas y procesos administrativos.');
INSERT Portal.Migraciones(Version) VALUES(1);
COMMIT;
GO
