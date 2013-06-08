/*
* Script para generar la tabla Ciudad y agregar datos a la misma
*/

USE [GD1C2013]
GO

/****** Object:  Table [dbo].[Ciudad]    Script Date: 06/08/2013 12:20:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Ciudad](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into dbo.Ciudad (nombre)
(
	select aut.Ciudad 
	from
	(
		select distinct(t1.Recorrido_Ciudad_Destino) as Ciudad
		from gd_esquema.Maestra2 t1
		union
		select distinct(t2.Recorrido_Ciudad_Origen) as Ciudad
		from gd_esquema.Maestra2 t2
	) as aut
) 