USE master;
GO
IF DB_ID(N'Essco_Portal') IS NOT NULL
    THROW 51000, 'Essco_Portal ya existe. No se reemplazará una base existente.', 1;
GO
CREATE DATABASE [Essco_Portal];
GO
