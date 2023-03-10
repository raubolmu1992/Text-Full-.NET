USE [Pedalea]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 4/1/2023 10:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[TipoProducto] [varchar](60) NULL,
	[CodigoUnico] [varchar](60) NULL,
	[NombreProducto] [varchar](60) NULL,
	[Activo] [varchar](60) NULL,
	[Cantidad] [varchar](60) NULL,
	[Valor] [numeric](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_eliminar]    Script Date: 4/1/2023 10:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_eliminar](
@IdProducto int
)
as
begin

delete from productos where IdProducto = @IdProducto

end

GO
/****** Object:  StoredProcedure [dbo].[usp_listar]    Script Date: 4/1/2023 10:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_listar]
as
begin

select * from productos
end


GO
/****** Object:  StoredProcedure [dbo].[usp_modificar]    Script Date: 4/1/2023 10:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_modificar](
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

GO
/****** Object:  StoredProcedure [dbo].[usp_obtener]    Script Date: 4/1/2023 10:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_obtener](@IdProducto int)
as
begin

select * from productos where IdProducto = @IdProducto
end

GO
/****** Object:  StoredProcedure [dbo].[usp_registrar]    Script Date: 4/1/2023 10:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure [dbo].[usp_registrar](
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


GO
