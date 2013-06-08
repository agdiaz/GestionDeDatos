--Ejecutivo = 100%
--Premium = 80%
--Cama = 60%
--Semi-Cama = 40%
--Comun = 20%

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Servicio]    Script Date: 06/08/2013 16:27:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Servicio](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[tipo_servicio] [nvarchar](255) NOT NULL,
	[pocent_adic] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Servicio (tipo_servicio, pocent_adic)
(
	select m.Tipo_Servicio,
				( ROUND ( ((SUM (m.Pasaje_Precio) ) * 100 ) / (SUM (m.Recorrido_Precio_BasePasaje)), 0) - 100 ) as porcentaje
	from gd_esquema.Maestra m
	group by Tipo_Servicio
)