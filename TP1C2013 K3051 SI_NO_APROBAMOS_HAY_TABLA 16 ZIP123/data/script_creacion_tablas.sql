/*===========================SCHEMA=============================*/
USE [GD1C2013]
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'SI_NO_APROBAMOS_HAY_TABLA')
EXEC sys.sp_executesql N'CREATE SCHEMA [SI_NO_APROBAMOS_HAY_TABLA] AUTHORIZATION [dbo]'
GO

/*===========================CIUDAD=============================*/

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

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] ADD  CONSTRAINT [DF_Ciudad_baja]  DEFAULT ((0)) FOR [baja]
GO

SET ANSI_PADDING OFF
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Ciudad (nombre)
(
	select aut.Ciudad 
	from
	(
		select distinct(t1.Recorrido_Ciudad_Destino) as Ciudad
		from gd_esquema.Maestra t1
		union
		select distinct(t2.Recorrido_Ciudad_Origen) as Ciudad
		from gd_esquema.Maestra t2
	) as aut
) 

CREATE NONCLUSTERED INDEX [indice_Ciudad_nombre] ON [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/*===========================MARCA==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [dbo].[Marca]    Script Date: 06/08/2013 12:53:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Marca] ADD  CONSTRAINT [DF_Marca_baja]  DEFAULT ((0)) FOR [baja]
GO

SET ANSI_PADDING OFF
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Marca (nombre)
(
	select distinct m.Micro_Marca
	from gd_esquema.Maestra m
)

CREATE NONCLUSTERED INDEX [indice_Marca_nombre] ON [SI_NO_APROBAMOS_HAY_TABLA].[Marca] 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/*===========================CLIENTE==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 06/08/2013 13:22:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Cliente](
	[dni] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[direccion] [nvarchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
	[mail] [nvarchar](255) NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[es_discapacitado] [char](1) NULL,
	[sexo] [varchar](50) NULL,
	[inhabilitado] [bit] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ADD  CONSTRAINT [DF_Cliente_inhabilitado]  DEFAULT ((0)) FOR [inhabilitado]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ADD  CONSTRAINT [DF_Cliente_baja]  DEFAULT ((0)) FOR [baja]
GO

SET ANSI_PADDING OFF
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Cliente (dni, nombre, apellido, direccion, telefono, mail, fecha_nacimiento)
(
	select distinct m.Cli_Dni as dni, m.Cli_Nombre as nombre, m.Cli_Apellido as apellido, 
			m.Cli_Dir as direccion, m.Cli_Telefono as telefono, m.Cli_Mail as mail,
			m.Cli_Fecha_Nac as fecha_nacimiento
	from gd_esquema.Maestra m
)

CREATE NONCLUSTERED INDEX [indice_Cliente_nombre] ON [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_Cliente_apellido] ON [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] 
(
	[apellido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_Cliente_direccion] ON [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] 
(
	[direccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/*===========================SERVICIO==============================*/

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
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Servicio] ADD CONSTRAINT [DF_Servicio_baja]  DEFAULT ((0)) FOR [baja]
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Servicio (tipo_servicio, pocent_adic)
(
	select m.Tipo_Servicio,
				( ROUND ( ((SUM (m.Pasaje_Precio) ) * 100 ) / (SUM (m.Recorrido_Precio_BasePasaje)), 0) - 100 ) as porcentaje
	from gd_esquema.Maestra m
	group by Tipo_Servicio
)

/*===========================RECORRIDO==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]    Script Date: 06/13/2013 21:13:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido](
	[id_recorrido] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
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


SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Recorrido ON

insert into SI_NO_APROBAMOS_HAY_TABLA.Recorrido (id_recorrido, id_ciudad_origen, id_ciudad_destino, pre_base_kg, pre_base_pasaje, id_servicio)
(
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
)

GO

USE [GD1C2013]
GO

/****** Object:  Index [indice_recorrido_ciudad]    Script Date: 07/14/2013 11:45:15 ******/
CREATE NONCLUSTERED INDEX [indice_recorrido_destino] ON [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] 
(
	[id_ciudad_destino] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_recorrido_origen] ON [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] 
(
	[id_ciudad_origen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_recorrido_origen_destino] ON [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] 
(
	[id_ciudad_origen],
	[id_ciudad_destino]
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/*===========================MICROS==============================*/
USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Micros]    Script Date: 07/15/2013 19:22:46 ******/
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
	[baja_vida_util] [bit] NOT NULL,
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

CREATE NONCLUSTERED INDEX [indice_micros_patente] ON [SI_NO_APROBAMOS_HAY_TABLA].[Micros] 
(
	[patente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO



/*===========================BUTACA==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Butaca]    Script Date: 06/13/2013 23:58:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Butaca](
	[id_butaca] [int] IDENTITY(1,1) NOT NULL,
	[nro_butaca] [numeric](18,0) NOT NULL,
	[id_micro] [int] NOT NULL,
	[tipo_butaca] [nvarchar](50) NOT NULL,
	[piso] [numeric](18, 0) NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Butaca] PRIMARY KEY CLUSTERED 
(
	[id_butaca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Butaca]  WITH CHECK ADD  CONSTRAINT [FK_Butaca_Micros] FOREIGN KEY([id_micro])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ([id_micros])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Butaca] CHECK CONSTRAINT [FK_Butaca_Micros]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Butaca] ADD  CONSTRAINT [DF_Butaca_baja]  DEFAULT ((0)) FOR [baja]
GO


insert into SI_NO_APROBAMOS_HAY_TABLA.Butaca
	(nro_butaca, id_micro, tipo_butaca, piso)
(
	select	m2.Butaca_Nro		as nro_butaca,
			mic.id_micros		as id_micro,
			m2.Butaca_Tipo		as tipo_butaca,
			m2.Butaca_Piso		as piso
	from
	(
		select distinct m.Micro_Patente, m.Butaca_Nro,
				m.Butaca_Piso,	m.Butaca_Tipo
		from gd_esquema.Maestra m
		where m.Paquete_Codigo = 0 
	) as m2
	inner join SI_NO_APROBAMOS_HAY_TABLA.Micros mic
		on mic.patente = m2.Micro_Patente
)

CREATE NONCLUSTERED INDEX [indice_nro_butaca] ON [SI_NO_APROBAMOS_HAY_TABLA].[Butaca] 
(
	[nro_butaca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_butaca_mircro] ON [SI_NO_APROBAMOS_HAY_TABLA].[Butaca] 
(
	[id_micro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/*===========================VIAJE==============================*/

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

USE [GD1C2013]
GO

/****** Object:  Index [indice_viaje_recorrido]    Script Date: 07/14/2013 11:46:59 ******/
CREATE NONCLUSTERED INDEX [indice_viaje_recorrido] ON [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] 
(
	[id_recorrido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_viaje_micro] ON [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] 
(
	[id_micro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO




/*===========================ROL==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Rol]    Script Date: 06/15/2013 14:39:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[activado] [bit] NOT NULL,
	[inhabilitado] [bit] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Rol] ADD  CONSTRAINT [DF_Rol_inhabilitado]  DEFAULT ((0)) FOR [inhabilitado]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Rol] ADD  CONSTRAINT [activado]  DEFAULT ((1)) FOR [activado]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Rol] ADD  CONSTRAINT [DF_Rol_baja]  DEFAULT ((0)) FOR [baja]
GO

insert into SI_NO_APROBAMOS_HAY_TABLA.Rol (nombre) VALUES ('Administrativo')
insert into SI_NO_APROBAMOS_HAY_TABLA.Rol (nombre) VALUES ('Cliente')

/*===========================USUARIO==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Usuario]    Script Date: 06/15/2013 17:09:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_rol] [int] NOT NULL,
	[dni] [numeric](18, 0) NOT NULL UNIQUE,
	[username] [nvarchar](50) NOT NULL UNIQUE,
	[hash_password] [varbinary](32) NULL,
	[cant_intentos_fallidos] [int] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cliente] FOREIGN KEY([dni])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ([dni])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cliente]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([id_rol])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Rol] ([id_rol])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario] ADD  CONSTRAINT [DF_Usuario_cant_intentos_fallidos]  DEFAULT ((0)) FOR [cant_intentos_fallidos]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Usuario] ADD  CONSTRAINT [DF_Usuario_baja]  DEFAULT ((0)) FOR [baja]
GO


DECLARE @ROLCLI int
SET @ROLCLI = (select r.id_rol
				from SI_NO_APROBAMOS_HAY_TABLA.Rol r
				where nombre = 'Cliente')

insert into SI_NO_APROBAMOS_HAY_TABLA.Usuario
(id_rol, dni, username)
(
	select distinct @ROLCLI							as id_rol,
					m.Cli_Dni						as dni,
					m.Cli_Dni						as username
	from gd_esquema.Maestra m
)

/*===========================FUNCIONALIDAD==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad]    Script Date: 06/15/2013 17:42:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](
	[id_funcionalidad] [int] IDENTITY(1,1) NOT NULL,
	[funcionalidad] [nvarchar](255) NOT NULL,
	[activa] [bit] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id_funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] ADD  CONSTRAINT [DF_Funcionalidad_activa]  DEFAULT ((1)) FOR [activa]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] ADD  CONSTRAINT [DF_Funcionalidad_baja]  DEFAULT ((0)) FOR [baja]
GO

/*===========================ROL_FUNCIONALIDAD==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad]    Script Date: 06/15/2013 17:55:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad](
	[id_rol] [int] NOT NULL,
	[id_funcionalidad] [int] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Rol_funcionalidad_1] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad] ADD  CONSTRAINT [DF_Rol_funcionalidad_baja]  DEFAULT ((0)) FOR [baja]
GO

/*===========================Cancelacion==============================*/
USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion]    Script Date: 07/15/2013 21:22:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion](
	[id_cancelacion] [int] IDENTITY(1,1) NOT NULL,
	[fecha_cancel] [datetime] NOT NULL,
	[motivo_cancel] [nvarchar](200) NULL,
 CONSTRAINT [PK_Cancelacion] PRIMARY KEY CLUSTERED 
(
	[id_cancelacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion] ADD  CONSTRAINT [DF_Cancelacion_fecha_cancel]  DEFAULT (getdate()) FOR [fecha_cancel]
GO


/*===========================COMPRAVACIA==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Compra]    Script Date: 06/20/2013 21:24:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra](
	[id_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_cancelacion] [int] NULL,
	[fecha_compra] [datetime] NOT NULL,
	[cancel] [bit] NOT NULL,
	[fecha_cancel] [datetime] NULL,
	[motivo_cancel] [nvarchar](200) NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[id_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Usuario] ([id_usuario])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra] CHECK CONSTRAINT [FK_Compra_Usuario]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cancelacion] FOREIGN KEY([id_cancelacion])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion] ([id_cancelacion])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra] CHECK CONSTRAINT [FK_Compra_Cancelacion]
GO



ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ADD  CONSTRAINT [DF_Compra_cancel]  DEFAULT ((0)) FOR [cancel]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ADD  CONSTRAINT [DF_Compra_baja]  DEFAULT ((0)) FOR [baja]
GO

CREATE NONCLUSTERED INDEX [indice_Compra_Usuario] ON [SI_NO_APROBAMOS_HAY_TABLA].[Compra] 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/*===========================PASAJE==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]    Script Date: 07/15/2013 21:01:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje](
	[id_pasaje] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_compra] [int] NOT NULL,
	[id_butaca] [int] NOT NULL,
	[id_cancelacion] [int] NULL,
	[dni] [numeric](18, 0) NOT NULL,
	[pre_pasaje] [numeric](18, 2) NOT NULL,
	[disponible] [bit] NOT NULL,
	[cancel] [bit] NOT NULL,
	[fecha_cancel] [datetime] NULL,
	[motivo_cancel] [nvarchar](200) NULL,
	[baja] [bit] NOT NULL,
	[id_viaje] [int] NOT NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[id_pasaje] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Butaca] FOREIGN KEY([id_butaca])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Butaca] ([id_butaca])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Butaca]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cancelacion] FOREIGN KEY([id_cancelacion])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion] ([id_cancelacion])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cancelacion]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cliente] FOREIGN KEY([dni])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ([dni])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cliente]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Compra] FOREIGN KEY([id_compra])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ([id_compra])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Compra]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([id_viaje])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] ([id_viaje])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Viaje]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] ADD  CONSTRAINT [DF_Pasaje_disponible]  DEFAULT ((1)) FOR [disponible]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] ADD  CONSTRAINT [DF_Pasaje_cancel]  DEFAULT ((0)) FOR [cancel]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] ADD  CONSTRAINT [DF_Pasaje_baja]  DEFAULT ((0)) FOR [baja]
GO

SET xact_abort on
GO
BEGIN TRANSACTION comprasPasajes
GO
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Recorrido OFF
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra ON
CREATE TABLE #tmpPasajes(
	ident				int IDENTITY(1,1),
	dni					numeric(18,0),
	patente				nvarchar(255),
	codRecorrido		numeric(18,0),
	fechaSalida			datetime,
	fechaLlegada		datetime,
	fechaLlegadaEst		datetime,
	codPasaje			numeric(18,0),
	prePasaje			numeric(18,0),
	fechaCompra			datetime,
	idRecorrido			numeric(18,0),
	butaca_nro			numeric(18,0)
)

INSERT INTO #tmpPasajes
SELECT	m.Cli_Dni,
		m.Micro_Patente,
		m.Recorrido_Codigo,
		m.FechaSalida,
		m.FechaLLegada,
		m.Fecha_LLegada_Estimada,
		m.Pasaje_Codigo,
		m.Pasaje_Precio,
		m.Pasaje_FechaCompra,
		m.Recorrido_Codigo,
		m.Butaca_Nro
FROM gd_esquema.Maestra m
WHERE m.Pasaje_Codigo <> 0

INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Compra
	(id_compra, id_usuario, fecha_compra)
(
	SELECT	m.ident				as id_compra,
			u.id_usuario		as id_usuario,
			m.fechaCompra		as fecha_compra
	FROM #tmpPasajes m
	inner join SI_NO_APROBAMOS_HAY_TABLA.Usuario u
		on u.dni = m.dni
)
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra OFF
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Pasaje ON

INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Pasaje
(id_pasaje, id_compra, id_butaca, dni, pre_pasaje, id_viaje)
(
	select	m.codPasaje		as id_pasaje,
			m.ident			as id_compra,
			b.id_butaca		as id_butaca,
			m.dni			as dni,
			m.prePasaje		as pre_pasaje,
			v.id_viaje		as id_viaje
	from #tmpPasajes m
	inner join SI_NO_APROBAMOS_HAY_TABLA.Micros mic
		on mic.patente = m.patente
	inner join SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		on mic.id_micros = v.id_micro
		and v.fecha_arribo = m.fechaLlegada
		and v.fecha_arribo_estimada = m.fechaLlegadaEst
		and v.fecha_salida = m.fechaSalida
		and v.id_recorrido = m.idRecorrido
	inner join SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		on mic.id_micros = b.id_micro
		and m.butaca_nro = b.nro_butaca
)
DROP TABLE #tmpPasajes

USE [GD1C2013]
GO


COMMIT TRANSACTION comprasPasajes
GO
CREATE NONCLUSTERED INDEX [indice_pasaje_viaje] ON [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] 
(
	[id_viaje] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_pasaje_compra] ON [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] 
(
	[id_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE TRIGGER trgPuntaje ON [SI_NO_APROBAMOS_HAY_TABLA].Pasaje
FOR INSERT
AS
	DECLARE @dni numeric(18,0)
	DECLARE @precio numeric(18,2)
	DECLARE @idCompra int
	
	SELECT @dni=i.dni FROM INSERTED i
	SELECT @precio=i.pre_pasaje FROM INSERTED i
	SELECT @idCompra=i.id_compra FROM INSERTED i
	
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
		(dni, id_compra, puntos)
	VALUES
		(@dni, @idCompra, @precio/5)
GO

/*===========================ENCOMIENDA==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda]    Script Date: 06/20/2013 21:58:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda](
	[id_encomienda] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_viaje] [int] NOT NULL,
	[id_compra] [int] NOT NULL,
	[id_cancelacion] [int] NULL,
	[dni] [numeric](18, 0) NOT NULL,
	[peso] [numeric](18, 0) NOT NULL,
	[pre_encomienda] [numeric](18, 0) NOT NULL,
	[cancel] [bit] NOT NULL,
	[fecha_cancel] [datetime] NULL,
	[motivo_cancel] [nvarchar](200) NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Encomienda] PRIMARY KEY CLUSTERED 
(
	[id_encomienda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Cliente] FOREIGN KEY([dni])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ([dni])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Cliente]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Compra] FOREIGN KEY([id_compra])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ([id_compra])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Compra]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Cancelacion] FOREIGN KEY([id_cancelacion])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion] ([id_cancelacion])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Cancelacion]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Viaje] FOREIGN KEY([id_viaje])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] ([id_viaje])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Viaje]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] ADD  CONSTRAINT [DF_Encomienda_cancel]  DEFAULT ((0)) FOR [cancel]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] ADD  CONSTRAINT [DF_Encomienda_baja]  DEFAULT ((0)) FOR [baja]
GO


SET xact_abort on
BEGIN TRANSACTION comprasEncomiendas

DECLARE @proxId int
SELECT @proxId=IDENT_CURRENT('SI_NO_APROBAMOS_HAY_TABLA.Compra') + 1

CREATE TABLE #tmpEncomiendas(
--	ident				int,
	dni					numeric(18,0),
	patente				nvarchar(255),
	codRecorrido		numeric(18,0),
	fechaSalida			datetime,
	fechaLlegada		datetime,
	fechaLlegadaEst		datetime,
	codEncomienda		numeric(18,0),
	preEncomienda		numeric(18,2),
	fechaCompra			datetime,
	peso				numeric(18,0)
)

INSERT INTO #tmpEncomiendas
SELECT	m.Cli_Dni,
		m.Micro_Patente,
		m.Recorrido_Codigo,
		m.FechaSalida,
		m.FechaLLegada,
		m.Fecha_LLegada_Estimada,
		m.Paquete_Codigo,
		m.Paquete_Precio,
		m.Paquete_FechaCompra,
		m.Paquete_KG
FROM gd_esquema.Maestra m
WHERE m.Paquete_Codigo <> 0

DECLARE @sql VARCHAR(2000)
SET @sql = 'ALTER TABLE #tmpEncomiendas ADD ident INT NOT NULL IDENTITY(' + CAST(@proxId AS VARCHAR) + ', 1)'
EXEC(@sql)

SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Pasaje OFF
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra ON

INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Compra
	(id_compra, id_usuario, fecha_compra)
(
	SELECT	m.ident				as id_compra,
			u.id_usuario		as id_usuario,
			m.fechaCompra		as fecha_compra
	FROM #tmpEncomiendas m
	inner join SI_NO_APROBAMOS_HAY_TABLA.Usuario u
		on u.dni = m.dni
)
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra OFF
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Encomienda ON
INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Encomienda
(id_encomienda, id_viaje, id_compra, dni, peso, pre_encomienda)
(
	select	m.codEncomienda	as id_encomienda,
			v.id_viaje		as id_viaje,
			m.ident			as id_compra,
			m.dni			as dni,
			m.peso			as peso,
			m.preEncomienda	as pre_encomienda
			
	from #tmpEncomiendas m
	inner join SI_NO_APROBAMOS_HAY_TABLA.Micros mic
		on mic.patente = m.patente
	inner join SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		on mic.id_micros = v.id_micro
		and v.fecha_arribo = m.fechaLlegada
		and v.fecha_arribo_estimada = m.fechaLlegadaEst
		and v.fecha_salida = m.fechaSalida
		and v.id_recorrido = m.codRecorrido
)
DROP TABLE #tmpEncomiendas

CREATE NONCLUSTERED INDEX [indice_encomienda_compra] ON [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] 
(
	[id_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


COMMIT TRANSACTION comprasEncomiendas
GO
CREATE TRIGGER trgPuntaje2 ON [SI_NO_APROBAMOS_HAY_TABLA].Encomienda
FOR INSERT
AS
	DECLARE @dni numeric(18,0)
	DECLARE @precio numeric(18,2)
	DECLARE @idCompra int
	
	SELECT @dni=i.dni FROM INSERTED i
	SELECT @precio=i.pre_encomienda FROM INSERTED i
	SELECT @idCompra=i.id_compra FROM INSERTED i
	
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
		(dni, id_compra, puntos)
	VALUES
		(@dni, @idCompra, @precio/5)
GO

/*===========================Baja Servicio Micro==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Baja_servicio_micro]    Script Date: 07/15/2013 19:26:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Baja_servicio_micro](
	[id_baja_servicio_micro] [int] IDENTITY(1,1) NOT NULL,
	[id_micros] [int] NOT NULL,
	[fec_fuera_servicio] [datetime] NOT NULL,
	[fec_reinicio_servicio] [datetime] NULL,
 CONSTRAINT [PK_Baja_servicio_micro] PRIMARY KEY CLUSTERED 
(
	[id_baja_servicio_micro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Baja_servicio_micro]  WITH CHECK ADD  CONSTRAINT [FK_Baja_servicio_micro_Micros] FOREIGN KEY([id_micros])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Micros] ([id_micros])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Baja_servicio_micro] CHECK CONSTRAINT [FK_Baja_servicio_micro_Micros]
GO

/*===========================INSERT FUNCIONALIDAD==============================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmRolAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmRolListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmCiudadAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmCiudadListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmRecorridoAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmRecorridoListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmMicroAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmMicroListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmClienteListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmClienteAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmViajeAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmViajeListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmPremiosAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmPremiosListado')

--    FUNCIONALIDADES AGREGADAS

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmEstadisticasListados')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmAyudaUsuarios')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmClientePasajeroFrecuente')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmClientePasajeroFrecuenteConsultar')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroServicio')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroServicioListado')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroServicioAlta')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroMarca')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroMarcaListado')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroMarcaAlta')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroButaca')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmMicroButacaAlta')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('cargarArribaToolStripMenuItem')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('canjeDePuntosToolStripMenuItem')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmComprarPasajes')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmPasajesListar')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmEncomiendasListar')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmCancelacionesCompra')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmCancelacionesPasaje')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('tsmCancelacionesEncomienda')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
VALUES ('canjearPuntosToolStripMenuItem')

/*===========================INSERT ROL FUNCIONALIDAD==============================*/

/*======================CLIENTE=======================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmClienteListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmClientePasajeroFrecuenteConsultar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmPasajeEncomiendaAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmEncomiendaCancelar'

/*======================ADMINISTRATIVO===================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRolAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRolListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCiudadAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCiudadListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRecorridoAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRecorridoListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicRolistado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClienteListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClienteAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmViajeAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmViajeListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEncomiendaAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEncomiendaCancelar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPremiosAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPremiosListado'

/*=============NUEVAS FUNCIONALIDADES PARA ADMINISTRATIVO=================================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasListados'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmAyudaUsuarios'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClientePasajeroFrecuente'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClientePasajeroFrecuenteConsultar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroServicio'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroServicioListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroServicioAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroMarca'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroMarcaListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroMarcaAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroButaca'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroButacaAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='cargarArribaToolStripMenuItem'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='canjeDePuntosToolStripMenuItem'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmComprarPasajes'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPasajesListar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEncomiendasListar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCancelacionesCompra'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCancelacionesPasaje'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCancelacionesEncomienda'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='canjearPuntosToolStripMenuItem'

/*===========================INSERT CLIENTES ADMINISTRATIVOS==============================*/

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (99999999
           ,'Administrativo Uno'
           ,'Administracion'
           ,'Direccion'
           ,'40000000'
           ,'administrativo_uno@administracion'
           ,GETDATE()
           ,'N'
           ,'Masc')
           
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (99999998
           ,'Administrativo Dos'
           ,'Administracion'
           ,'Direccion'
           ,'40000000'
           ,'administrativo_dos@administracion'
           ,GETDATE()
           ,'N'
           ,'Masc')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (99999997
           ,'Administrativo Tres'
           ,'Administracion'
           ,'Direccion'
           ,'40000000'
           ,'administrativo_tres@administracion'
           ,GETDATE()
           ,'N'
           ,'Masc')

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (99999996
           ,'Administrativo Cuatro'
           ,'Administracion'
           ,'Direccion'
           ,'40000000'
           ,'administrativo_cuatro@administracion'
           ,GETDATE()
           ,'N'
           ,'Masc')

/*===========================INSERT USUARIOS ADMINISTRATIVOS==============================*/

Declare @id_rol_administrativo int

SELECT @id_rol_administrativo = R.id_rol
FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Rol R
WHERE R.nombre = 'Administrativo'

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999999
           ,'admin1'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999998
           ,'admin2'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)
           
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999997
           ,'admin3'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999996
           ,'admin4'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)


/*===========================Tabla Puntajes=======================================*/
USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje]    Script Date: 07/14/2013 14:04:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje](
	[id_puntaje] [int] IDENTITY(1,1) NOT NULL,
	[dni] [numeric](18, 0) NOT NULL,
	[id_compra] [int] NOT NULL,
	[puntos] [int] NOT NULL,
	[puntos_usados] [int] NOT NULL,
	[fecha_otorgado] [datetime] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Puntaje] PRIMARY KEY CLUSTERED 
(
	[id_puntaje] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje]  WITH CHECK ADD  CONSTRAINT [FK_Puntaje_Cliente] FOREIGN KEY([dni])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ([dni])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje] CHECK CONSTRAINT [FK_Puntaje_Cliente]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje]  WITH CHECK ADD  CONSTRAINT [FK_Puntaje_Compra] FOREIGN KEY([id_compra])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ([id_compra])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje] CHECK CONSTRAINT [FK_Puntaje_Compra]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje] ADD  CONSTRAINT [DF_Puntaje_puntos_usados]  DEFAULT ((0)) FOR [puntos_usados]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje] ADD  CONSTRAINT [DF_Puntaje_fecha_otorgado]  DEFAULT (getdate()) FOR [fecha_otorgado]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje] ADD  CONSTRAINT [DF_Puntaje_baja]  DEFAULT ((0)) FOR [baja]
GO


INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
	(dni, id_compra, puntos, fecha_otorgado)
SELECT p.dni, p.id_compra, (p.pre_pasaje/5) , c.fecha_compra
FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Compra c
	ON c.id_compra = p.id_compra

GO

INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
	(dni, id_compra, puntos, fecha_otorgado)
SELECT e.dni, e.id_compra, (e.pre_encomienda/5), c.fecha_compra
FROM SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Compra c
	ON c.id_compra = e.id_compra

GO


CREATE NONCLUSTERED INDEX [indice_Cliente_nombre] ON [SI_NO_APROBAMOS_HAY_TABLA].[Puntaje] 
(
	[dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/*================================TABLA RECOMPENSA================================*/
USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]    Script Date: 07/14/2013 12:58:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recompensa](
	[id_recompensa] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[stock] [int] NOT NULL,
	[puntos_costo] [int] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Recompensa] PRIMARY KEY CLUSTERED 
(
	[id_recompensa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Recompensa] ADD  CONSTRAINT [DF_Recompensa_baja]  DEFAULT ((0)) FOR [baja]
GO

ALTER TABLE SI_NO_APROBAMOS_HAY_TABLA.Recompensa
ADD CONSTRAINT check_stock CHECK (stock >= 0)

GO

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('Lapicera',10,5)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('Viaje al Caribe',5,10000)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('Par de medias',20,10)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('Casette Suavemente de Elvis Crespo',150,100)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('Ejercitador Shake Weight',20,350)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('CD Pimpinela: Grandes exitos',20,215)

GO

/*==============================Tabla Canje=======================================*/
USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Canje]    Script Date: 07/14/2013 13:06:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Canje](
	[id_canje] [int] IDENTITY(1,1) NOT NULL,
	[dni] [numeric](18, 0) NOT NULL,
	[id_recompensa] [int] NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Canje] PRIMARY KEY CLUSTERED 
(
	[id_canje] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Cliente] FOREIGN KEY([dni])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Cliente] ([dni])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Canje] CHECK CONSTRAINT [FK_Canje_Cliente]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Recompensa] FOREIGN KEY([id_recompensa])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Recompensa] ([id_recompensa])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Canje] CHECK CONSTRAINT [FK_Canje_Recompensa]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Canje] ADD  CONSTRAINT [DF_Canje_baja]  DEFAULT ((0)) FOR [baja]
GO