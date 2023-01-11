use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'Pedalea')
CREATE DATABASE Pedalea

GO 
USE Pedalea
GO

--Crea tabla empleados 
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'productos')
create table productos(
IdProducto int primary key identity(1,1),
TipoProducto  varchar(60),
CodigoUnico varchar(60),
NombreProducto varchar(60),
Activo varchar(60),
Cantidad varchar(60),
Valor varchar(60)
)
go

ALTER TABLE productos ALTER COLUMN Valor numeric
select * from dbo.productos


go


