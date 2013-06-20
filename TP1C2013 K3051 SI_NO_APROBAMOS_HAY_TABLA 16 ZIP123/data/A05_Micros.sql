USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Micros]    Script Date: 06/13/2013 23:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros](
	[id_micros] [int] IDENTITY(1,1) NOT NULL,
	[fecha_alta] [datetime2](7) NOT NULL,
	[nro_micro] [int] NULL,
	[modelo] [nvarchar](50) NOT NULL,
	[patente] [nvarchar](50) NOT NULL,
	[id_marca] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[baja_fuera_servicio] [bit] NOT NULL,
	[baja_vida_util] [bit] NOT NULL,
	[fec_fuera_servicio] [datetime] NULL,
	[fec_reinicio_servicio] [datetime] NULL,
	[fec_baja_vida_util] [datetime] NULL,
	[capacidad_kg] [numeric](18, 2) NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Micros] PRIMARY KEY CLUSTERED 
(
	[id_micros] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros]  WITH CHECK ADD  CONSTRAINT [FK_Micros_Marcas] FOREIGN KEY([id_marca])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Marca] ([id_marca])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros] CHECK CONSTRAINT [FK_Micros_Marcas]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros]  WITH CHECK ADD  CONSTRAINT [FK_Micros_Servicios] FOREIGN KEY([id_servicio])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Servicio] ([id_servicio])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros] CHECK CONSTRAINT [FK_Micros_Servicios]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ADD  CONSTRAINT [DF_Micros_fecha_alta]  DEFAULT (getdate()) FOR [fecha_alta]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ADD  CONSTRAINT [DF_Micros_baja_fuera_servicio]  DEFAULT ((0)) FOR [baja_fuera_servicio]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ADD  CONSTRAINT [DF_Micros_baja_vida_util]  DEFAULT ((0)) FOR [baja_vida_util]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ADD  CONSTRAINT [DF_Micros_baja]  DEFAULT ((0)) FOR [baja]
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Micros
	(modelo, patente, id_marca, id_servicio, capacidad_kg)
(
	select m2.Micro_Modelo			as modelo,
			m2.Micro_Patente		as patente,
			mar.id_marca			as id_marca,
			serv.id_servicio		as id_servicio,
			m2.Micro_KG_Disponibles as capacidad_kg
	from
	(
		select distinct m.Micro_Modelo, m.Micro_Patente, 
					m.Micro_Marca, m.Tipo_Servicio,
					m.Micro_KG_Disponibles
		from gd_esquema.Maestra m
	) as m2
	inner join SI_NO_APROBAMOS_HAY_TABLA.Marca mar
		on mar.nombre = m2.Micro_Marca
	inner join SI_NO_APROBAMOS_HAY_TABLA.Servicio serv
		on serv.tipo_servicio = m2.Tipo_Servicio
)