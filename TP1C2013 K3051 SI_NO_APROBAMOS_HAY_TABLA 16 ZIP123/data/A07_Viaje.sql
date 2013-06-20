USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Viaje]    Script Date: 06/15/2013 13:55:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Viaje](
	[id_viaje] [int] IDENTITY(1,1) NOT NULL,
	[id_recorrido] [numeric](18, 0) NOT NULL,
	[id_micro] [int] NOT NULL,
	[fecha_salida] [datetime] NOT NULL,
	[fecha_arribo_estimada] [datetime] NOT NULL,
	[fecha_arribo] [datetime] NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[id_viaje] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Micro] FOREIGN KEY([id_micro])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ([id_micros])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] CHECK CONSTRAINT [FK_Viaje_Micro]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Recorrido] FOREIGN KEY([id_recorrido])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] ([id_recorrido])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] CHECK CONSTRAINT [FK_Viaje_Recorrido]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] ADD  CONSTRAINT [DF_Viaje_baja]  DEFAULT ((0)) FOR [baja]
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Viaje
	(id_recorrido, id_micro, fecha_salida,fecha_arribo_estimada, fecha_arribo)
(
	select		rec.id_recorrido			as id_recorrido,
				mic.id_micros				as id_micro,
				m2.FechaSalida				as fecha_salida,
				m2.Fecha_LLegada_Estimada	as fecha_arribo_estimada,
				m2.FechaLLegada				as fecha_arribo
	from
	(
		select distinct m.Recorrido_Codigo, m.Micro_Patente, m.FechaSalida, m.Fecha_LLegada_Estimada, m.FechaLLegada 
		from gd_esquema.Maestra m
	) as m2
	inner join SI_NO_APROBAMOS_HAY_TABLA.Recorrido rec
		on rec.id_recorrido = m2.Recorrido_Codigo
	inner join SI_NO_APROBAMOS_HAY_TABLA.Micros mic
		on mic.patente = m2.Micro_Patente
)