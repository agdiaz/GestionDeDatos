USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]    Script Date: 06/13/2013 21:13:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido](
	[id_recorrido] [numeric](18, 0) NOT NULL,
	[id_ciudad_origen] [int] NOT NULL,
	[id_ciudad_destino] [int] NOT NULL,
	[pre_base_kg] [numeric](18, 2) NOT NULL,
	[pre_base_pasaje] [numeric](18, 2) NOT NULL,
	[id_servicio] [int] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Recorrido] PRIMARY KEY CLUSTERED 
(
	[id_recorrido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]  WITH CHECK ADD  CONSTRAINT [FK_Recorrido_Destino] FOREIGN KEY([id_ciudad_destino])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] ([id_ciudad])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] CHECK CONSTRAINT [FK_Recorrido_Destino]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]  WITH CHECK ADD  CONSTRAINT [FK_Recorrido_Origen] FOREIGN KEY([id_ciudad_origen])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] ([id_ciudad])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] CHECK CONSTRAINT [FK_Recorrido_Origen]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]  WITH CHECK ADD  CONSTRAINT [FK_Recorrido_Servicio] FOREIGN KEY([id_servicio])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Servicio] ([id_servicio])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] CHECK CONSTRAINT [FK_Recorrido_Servicio]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] ADD  CONSTRAINT [DF_Recorrido_baja]  DEFAULT ((0)) FOR [baja]
GO

select	m2.Recorrido_Codigo					as id_recorrido, 
		corig.id_ciudad						as id_ciudad_origen,
		cdes.id_ciudad						as id_ciudad_destino,
		SUM(m2.Recorrido_Precio_BaseKG)		as pre_base_kg, 
		SUM(m2.Recorrido_Precio_BasePasaje)	as pre_base_pasaje,
		serv.id_servicio					as id_servicio
from( 
	select distinct m.Recorrido_Codigo, m.Recorrido_Ciudad_Origen,
					m.Recorrido_Ciudad_Destino,	m.Recorrido_Precio_BaseKG, 
					m.Recorrido_Precio_BasePasaje, m.Tipo_Servicio
	from gd_esquema.Maestra m
) as m2
inner join SI_NO_APROBAMOS_HAY_TABLA.Ciudad cdes
	on cdes.nombre = m2.Recorrido_Ciudad_Destino
inner join SI_NO_APROBAMOS_HAY_TABLA.Ciudad corig
	on corig.nombre = m2.Recorrido_Ciudad_Origen
inner join SI_NO_APROBAMOS_HAY_TABLA.Servicio serv
	on serv.tipo_servicio = m2.Tipo_Servicio
group by m2.Recorrido_Codigo, corig.id_ciudad, cdes.id_ciudad, serv.id_servicio
