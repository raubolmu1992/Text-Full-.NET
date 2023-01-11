go
use Pedalea
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrar')
DROP PROCEDURE usp_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificar')
DROP PROCEDURE usp_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtener')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listar')
DROP PROCEDURE usp_listar

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminar')
DROP PROCEDURE usp_eliminar

go


--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure usp_registrar(
@TipoProducto varchar(60),
@CodigoUnico varchar(60),
@NombreProducto varchar(60),
@Activo varchar(60),
@Cantidad varchar(60),
@Valor varchar(60)
)
as
begin

insert into productos(TipoProducto,CodigoUnico,NombreProducto,Activo,Cantidad,Valor)
values
(
@TipoProducto,
@CodigoUnico,
@NombreProducto,
@Activo,
@Cantidad,
@Valor
)

end


go

create procedure usp_modificar(
@IdProducto int,
@TipoProducto varchar(60),
@CodigoUnico varchar(60),
@NombreProducto varchar(60),
@Activo varchar(60),
@Cantidad varchar(60),
@Valor varchar(60)
)
as
begin

update productos set 
TipoProducto = @TipoProducto,
CodigoUnico = @CodigoUnico,
NombreProducto = @NombreProducto,
Activo = @Activo,
Cantidad = @Cantidad,
Valor = @Valor
where IdProducto = @IdProducto

end

go

create procedure usp_obtener(@IdProducto int)
as
begin

select * from productos where IdProducto = @IdProducto
end

go
create procedure usp_listar
as
begin

select * from productos
end


go

go

create procedure usp_eliminar(
@IdProducto int
)
as
begin

delete from productos where IdProducto = @IdProducto

end

go