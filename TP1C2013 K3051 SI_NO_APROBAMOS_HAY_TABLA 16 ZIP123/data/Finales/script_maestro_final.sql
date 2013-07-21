/*===========================SCHEMA=============================*/
USE [GD1C2013]
GO

--Si el schema no existe lo creamos
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'SI_NO_APROBAMOS_HAY_TABLA')
EXEC sys.sp_executesql N'CREATE SCHEMA [SI_NO_APROBAMOS_HAY_TABLA] AUTHORIZATION [dbo]'
GO

/*===========================CIUDAD=============================*/
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



GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[ArribosTemporal](
	[Id_viaje] [int] NOT NULL,
	[Fecha_arribo_real] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[ArribosTemporal]  WITH CHECK ADD  CONSTRAINT [FK_ArribosTemporal_Viaje] FOREIGN KEY([Id_viaje])
REFERENCES [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] ([id_viaje])
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[ArribosTemporal] CHECK CONSTRAINT [FK_ArribosTemporal_Viaje]
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

--Los dos roles basicos
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

--Todos los clientes que tenemos en la tabla Maestra ya son usuarios
--Como el username tiene que ser unique, utilizamos el dni como username por defecto
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


/*===============================COMPRA===================================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Compra]    Script Date: 06/20/2013 21:24:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--La tabla en este punto se deja vacia; se llenara junto con los pasajes y encomiendas
CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra](
	[id_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_cancelacion] [int] NULL,
	[fecha_compra] [datetime] NOT NULL,
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


ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] ADD  CONSTRAINT [DF_Pasaje_baja]  DEFAULT ((0)) FOR [baja]
GO

SET xact_abort on
GO
BEGIN TRANSACTION comprasPasajes
GO
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Recorrido OFF
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra ON
--Creamos una tabla temporal para poder almacenar las identidades 
--que generamos para las compras (campo ident)
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

--Primero insertamos en Compra con las identidades generadas
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

-- Luego insertamos en la tabla Pasaje usando las mismas identidades generadas
-- como FK de la tabla compras
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

--Este trigger otorgara los nuevos puntos a los clientes que compren pasajes
--Se agrega luego de la insercion de datos por performace del script inicial
--(la insercion en Puntaje se hara toda de una vez al final)
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

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] ADD  CONSTRAINT [DF_Encomienda_baja]  DEFAULT ((0)) FOR [baja]
GO


SET xact_abort on
BEGIN TRANSACTION comprasEncomiendas

--Al igual que Pasaje, se utiliza la tabla temporal para generar las identidades, 
--pero en este caso tenemos el problema de tener que iniciar con una identidad 
--ya inicializada... (solucion al problema mas adelante)
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

--Solucionamos el problema modificando la tabla temporal luego de la insercion, agregandole
--el campo ident pero comenzando desde la siguiente identidad a la ultima insertada en la tabla compras
DECLARE @proxId int
SELECT @proxId=IDENT_CURRENT('SI_NO_APROBAMOS_HAY_TABLA.Compra') + 1
DECLARE @sql VARCHAR(2000)
SET @sql = 'ALTER TABLE #tmpEncomiendas ADD ident INT NOT NULL IDENTITY(' + CAST(@proxId AS VARCHAR) + ', 1)'
EXEC(@sql)

SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Pasaje OFF
SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra ON

--Luego hacemos la insercion en la tabla compras de la misma forma que en Pasaje
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

--Al igual que en compras, este trigger otorga puntos por la encomienda al cliente
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

--Aqui insertamos las funcionalidades que consideramos apropiadas
insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmCancelacionesListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmViajeProcesarArribos')

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

--Aqui hacemos la relacion de cada rol con sus funcionalidades a traves de
--la tabla Rol_Funcionalidad para poder modelar la relacion de cardinalidad N a N
/*===================Rol Cliente=====================*/

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

/*=================Rol administrativo=================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCancelacionesListado'


insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmViajeProcesarArribos'

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

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recompensa]
	([descripcion],[stock],[puntos_costo])
VALUES ('Libro BBDD relacional for Dummies',12,350)

GO

/*==============================Tabla Canje=======================================*/
USE [GD1C2013]
GO

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

/*================================================================================*/
/*================================================================================*/
/*=============================SPs y funciones====================================*/
/*================================================================================*/
/*================================================================================*/
PRINT 'INICIO DEL SCRIPT'
PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\01_realizar_identificacion.sql'
GO 
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/06/2013
-- Description:	identifica usuarios y graba intentos fallidos
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].realizar_identificacion 
	-- Add the parameters for the stored procedure here
	@userName nvarchar(50),
	@passwordHash varbinary(32),
	@resultado int OUTPUT
AS
BEGIN
	-- 0 Exito
	-- -1 Bloqueado
	-- -2 Usuario invalido o contrasena falsa
	SET NOCOUNT ON;
	
	DECLARE @hashReal varbinary(32)
	DECLARE @fallidos int
	
	SELECT @hashReal=us.hash_password, @fallidos=us.cant_intentos_fallidos
	FROM SI_NO_APROBAMOS_HAY_TABLA.Usuario us
	WHERE us.username = @userName
	
	IF @@ROWCOUNT = 0
	BEGIN
		--Usuario invalido
		SET @resultado = -2
		RETURN
	END
	
	IF @fallidos >= 3
	BEGIN
		--Usuario bloqueado
		SET @resultado = -1
		RETURN
	END
	
	IF @hashReal = @passwordHash
	BEGIN
		--Exito
		UPDATE SI_NO_APROBAMOS_HAY_TABLA.Usuario
		SET cant_intentos_fallidos = 0
		WHERE username = @userName
		
		SET @resultado = 0
		
		RETURN
	END
	
	--Password incorrecto
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Usuario
	SET cant_intentos_fallidos = (cant_intentos_fallidos + 1)
	WHERE username = @userName
	
	SET @resultado = -2
	RETURN
		
END
GO


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\01_realizar_identificacion.sql'
PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\65_SP_cancel_compra.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_compra
	@id_compra	int,
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET baja = 1
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET baja = 1
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET baja = 1
	WHERE id_compra = @id_compra
	
	COMMIT TRANSACTION cancel
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\65_SP_cancel_compra.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\02_sp_obtener_usuario.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario]    Script Date: 07/16/2013 03:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario](

@p_username nvarchar(50)
)
AS
BEGIN
	SELECT 
	[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where username = @p_username
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\02_sp_obtener_usuario.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\03_sp_obtener_rol.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_rol
	@p_id int
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[activado]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	where Rol.id_rol = @p_id
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\03_sp_obtener_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\04_sp_listar_funcionalidades_rol.sql'
GO 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/6/2013
-- Description:	Selecciona las funcionalidades
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidades_rol(
	@p_id_rol int) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT f.[id_funcionalidad]
      ,f.[funcionalidad]
      ,f.[activa]
      ,f.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] f
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol_funcionalidad rf
		ON rf.id_funcionalidad = f.id_funcionalidad
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol r
		ON rf.id_rol = r.id_rol
	WHERE r.id_rol = @p_id_rol
	and r.baja = 0
	and f.baja = 0
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\04_sp_listar_funcionalidades_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\05_sp_listar_rol.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol
	AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[inhabilitado]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
  WHERE baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\05_sp_listar_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\06_sp_listar_funcionalidad.sql'
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidad
AS
BEGIN
SELECT [id_funcionalidad]
      ,[funcionalidad]
      ,[activa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad]
  WHERE baja = 0
 END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\06_sp_listar_funcionalidad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\07_sp_listar_filtrado_rol.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_rol]    Script Date: 07/16/2013 01:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_rol]
	@p_rol nvarchar(50) = NULL, @p_funcionalidad nvarchar(255) = NULL 
	AS
BEGIN
	SELECT distinct r.id_rol, r.[nombre], r.inhabilitado
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] r
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Rol_Funcionalidad rf
		on r.id_rol = rf.id_rol
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Funcionalidad f
		on rf.id_funcionalidad = f.id_funcionalidad
	where ((@p_rol IS NULL) OR (r.nombre like '%' + @p_rol + '%'))
	and ((@p_funcionalidad IS NULL) OR (f.funcionalidad like '%' +  @p_funcionalidad + '%'))
	and r.baja = 0
	and rf.baja = 0
	and f.baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\07_sp_listar_filtrado_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\08_sp_insert_rol.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]    Script Date: 07/16/2013 00:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT ROL==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]
(
	@p_nombre nvarchar(50),
	@p_inhabilitado bit,
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@p_nombre,@p_inhabilitado)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT ROL FUNCIONALIDAD==============================*/


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\08_sp_insert_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\09_sp_insert_rol_funcionalidad.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol_funcionalidad]
(
	@p_id_rol int,
	@p_id_funcionalidad int
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad]
           ([id_rol]
           ,[id_funcionalidad])
     VALUES (@p_id_rol, @p_id_funcionalidad)
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\09_sp_insert_rol_funcionalidad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\10_sp_baja_funcionalidades.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_baja_funcionalidades]
(
	@p_id_rol int 
)
AS
BEGIN

DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad]
	WHERE Rol_funcionalidad.id_rol = @p_id_rol
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\10_sp_baja_funcionalidades.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\11_sp_delete_rol.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_delete_rol]    Script Date: 07/16/2013 00:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_delete_rol]
(
	@p_id_rol int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	SET baja=1
	WHERE Rol.id_rol = @p_id_rol
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\11_sp_delete_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\12_sp_listar_ciudad.sql'
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_ciudad 
AS
BEGIN
	SELECT [id_ciudad],[nombre],[baja]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\12_sp_listar_ciudad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\13_sp_listar_filtrado_ciudad.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_ciudad]    Script Date: 07/16/2013 01:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_ciudad] 
	@p_nombre varchar(50) = NULL
AS
BEGIN
	SELECT c.[id_ciudad],c.[nombre]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] c
	where ((@p_nombre IS NULL) OR (c.nombre like '%' + @p_nombre + '%'))	
	and baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\13_sp_listar_filtrado_ciudad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\14_sp_insert_ciudad.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]    Script Date: 07/16/2013 01:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT CIUDAD==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@p_nombre)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT CLIENTE==============================*/


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\14_sp_insert_ciudad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\15_sp_update_ciudad.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_ciudad(
	@p_nombre varchar(50),
	@p_id int
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Ciudad
	SET nombre = @p_nombre
	WHERE id_ciudad = @p_id
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\15_sp_update_ciudad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\16_sp_delete_ciudad.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_ciudad
(
@p_id_ciudad INT
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Ciudad
	SET baja=1			
	WHERE id_ciudad=@p_id_ciudad
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\16_sp_delete_ciudad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\17_sp_listar_servicio.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_servicio
AS
BEGIN
  SELECT [id_servicio]
	,[tipo_servicio]
	,[pocent_adic]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
  WHERE [baja] = 0
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\17_sp_listar_servicio.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\18_sp_listar_recorrido.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_recorrido
	AS
BEGIN
	SELECT r.[id_recorrido]
      ,r.[id_ciudad_origen]
	  ,co.[nombre] as 'nombreOrigen'
      ,r.[id_ciudad_destino]
      ,cd.[nombre] as 'nombreDestino'
	  ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
      ,r.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] co
	ON r.id_ciudad_origen = co.id_ciudad
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] cd
	ON r.id_ciudad_destino = cd.id_ciudad
  WHERE r.[baja] = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\18_sp_listar_recorrido.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\19_sp_obtener_cliente.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_cliente
	@p_dni numeric(18,0)
AS
BEGIN
	SELECT TOP 1 [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	WHERE Cliente.dni = @p_dni
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\19_sp_obtener_cliente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\20_sp_obtener_ciudad.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_ciudad(
	@p_id int
)
AS
BEGIN
	SELECT [id_ciudad]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE Ciudad.id_ciudad = @p_id
END
GO


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\20_sp_obtener_ciudad.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\21_sp_obtener_servicio.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_servicio
	@p_id int
AS
BEGIN
	SELECT s.id_servicio, s.tipo_servicio, s.pocent_adic
	from SI_NO_APROBAMOS_HAY_TABLA.Servicio s
	where s.id_servicio = @p_id
END
GO


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\21_sp_obtener_servicio.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\22_sp_listar_filtrado_recorrido.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]    Script Date: 07/16/2013 02:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]
	@p_id_ciudad_origen int=NULL,
	@p_id_ciudad_destino int=NULL, 
	@p_id_servicio int=NULL
	AS
BEGIN
	SELECT distinct r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r 
	where ((@p_id_ciudad_origen IS NULL) OR (r.id_ciudad_origen = @p_id_ciudad_origen))
	and ((@p_id_ciudad_destino IS NULL) OR (r.id_ciudad_destino = @p_id_ciudad_destino))
	and ((@p_id_servicio IS NULL) OR ( r.id_servicio = @p_id_servicio))
	and r.baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\22_sp_listar_filtrado_recorrido.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\23_sp_insert_recorrido.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_recorrido
(
	@p_id int output,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
           ([id_ciudad_origen]
           ,[id_ciudad_destino]
           ,[pre_base_kg]
           ,[pre_base_pasaje]
           ,[id_servicio])
	VALUES
           (@p_id_ciudad_origen,
           @p_id_ciudad_destino,
           @p_pre_base_kg,
           @p_pre_base_pasaje,
           @p_id_servicio)
           
	  SET @p_id = SCOPE_IDENTITY()
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\23_sp_insert_recorrido.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\24_sp_update_recorrido.sql'
GO 
USE [GD1C2013]
GO

/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_recorrido]    Script Date: 07/16/2013 03:04:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_recorrido]
(
	@p_id int,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Recorrido
SET id_ciudad_origen = @p_id_ciudad_origen,
	id_ciudad_destino = @p_id_ciudad_destino,
	pre_base_kg = @p_pre_base_kg,
	pre_base_pasaje = @p_pre_base_pasaje,
	id_servicio = @p_id_servicio 
	
WHERE id_recorrido =@p_id
END

GO



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\24_sp_update_recorrido.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\26.sp_baja_recorrido.sql'
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_recorrido
	@id_recorrido numeric(18,0) 
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_recorrido
	DECLARE @motivo nvarchar(200)
	SET @motivo = 'Baja de recorrido'
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Recorrido 
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	--Doy de baja todas las compras del recorrido
	declare @idCompraAct int

	declare cur CURSOR LOCAL for
		SELECT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Compra c
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_compra = c.id_compra
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON p.id_viaje = v.id_viaje
			AND v.id_recorrido = @id_recorrido
		WHERE c.id_cancelacion IS NULL
		
	open cur

	fetch next from cur into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, @motivo
		fetch next from cur into @idCompraAct 
	END

	close cur
	deallocate cur

	COMMIT TRANSACTION baja_recorrido	
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\26.sp_baja_recorrido.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\27_sp_listar_marca.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_marca
AS
BEGIN
SELECT [id_marca],[nombre]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
  WHERE
  baja = 0
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\27_sp_listar_marca.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\28_sp_listar_micros.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]    Script Date: 07/16/2013 20:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]
AS
BEGIN
SELECT Mi.[id_micros]
      ,Mi.[fecha_alta]
      ,Mi.[nro_micro]
      ,Mi.[modelo]
      ,Mi.[patente]
      ,Ma.nombre
      ,Ma.id_marca
      ,Mi.[id_servicio]
      ,Mi.[baja_vida_util]
      ,Mi.[fec_baja_vida_util]
      ,Mi.[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] Mi
  INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Marca Ma
	on Mi.id_marca = Ma.id_marca
  WHERE Mi.baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\28_sp_listar_micros.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\29_sp_obtener_marca.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_marca
	@p_id int
AS
BEGIN
SELECT [id_marca]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
	WHERE id_marca = @p_id
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\29_sp_obtener_marca.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\30_sp_listar_filtrado_micros.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_micros
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_nro_micro int = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL 
AS
BEGIN
	SELECT m.[id_micros]
      ,m.[fecha_alta]
      ,m.[nro_micro]
      ,m.[modelo]
      ,m.[patente]
      ,m.[id_marca]
      ,m.[id_servicio]
      ,m.[baja_vida_util]
      ,m.[fec_baja_vida_util]
      ,m.[capacidad_kg]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] m
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on s.id_servicio = m.id_servicio
	left join SI_NO_APROBAMOS_HAY_TABLA.Marca ma
		on ma.id_marca = m.id_marca 
	where ((@p_modelo IS NULL) OR (m.modelo like '%' + @p_modelo + '%' ))
	and ((@p_patente IS NULL) OR (m.patente like '%' + @p_patente + '%' ))
	and ((@p_nro_micro IS NULL) OR (m.nro_micro = @p_nro_micro ))
	and ((@p_kgs_encomienda IS NULL) OR (m.capacidad_kg = @p_kgs_encomienda ))
	and ((@p_marca IS NULL) OR (ma.nombre = @p_marca))
	and ((@p_tipo_servicio IS NULL) OR (s.tipo_servicio = @p_tipo_servicio ))
	and m.baja = 0
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\30_sp_listar_filtrado_micros.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\31_sp_insert_micro.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_micro]    Script Date: 07/20/2013 01:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_micro]
(
	@p_fecha_alta datetime2(7),
	@p_nro_micro int,
	@p_modelo nvarchar(50),
	@p_patente nvarchar(50),
	@p_id_marca int,
	@p_id_servicio int,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime = NULL,
	@p_capacidad_kg numeric(18,2),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
           ([fecha_alta]
           ,[nro_micro]
           ,[modelo]
           ,[patente]
           ,[id_marca]
           ,[id_servicio]
           ,[baja_vida_util]
           ,[fec_baja_vida_util]
           ,[capacidad_kg]
           ,[baja])
     VALUES
           (@p_fecha_alta
           ,@p_nro_micro
           ,@p_modelo
           ,@p_patente
           ,@p_id_marca
           ,@p_id_servicio
           ,@p_baja_vida_util
           ,@p_fec_baja_vida_util
           ,@p_capacidad_kg
           ,0)
	SET @p_id = SCOPE_IDENTITY()
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\31_sp_insert_micro.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\32_sp_insert_butaca.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_butaca
(

	@p_nro_butaca numeric(18,0),
	@p_id_micro int,
	@p_tipo_butaca nvarchar(50),
	@p_piso numeric(18,0),
	@p_id int output
)

AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
           ([nro_butaca]
           ,[id_micro]
           ,[tipo_butaca]
           ,[piso])
     VALUES
           (@p_nro_butaca
           ,@p_id_micro
           ,@p_tipo_butaca
           ,@p_piso)

SET @p_id = SCOPE_IDENTITY()

END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\32_sp_insert_butaca.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\33_sp_update_micro.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_micro]
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL,
	@p_fecha_alta datetime,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
   SET [fecha_alta] = @p_fecha_alta
      ,[modelo] = @p_modelo
      ,[patente] = @p_patente
      ,[id_marca] = @p_marca
      ,[id_servicio] = @p_tipo_servicio
      ,[baja_vida_util] = @p_baja_vida_util
      ,[fec_baja_vida_util] = @p_fec_baja_vida_util
      ,[capacidad_kg] = @p_kgs_encomienda
      
 WHERE id_micros = @p_id
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\33_sp_update_micro.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\34_sp_baja_logica_micro.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_logica_micro
	
	DECLARE @idCompraAct int

	DECLARE cur_compras CURSOR LOCAL for
		SELECT DISTINCT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_viaje = v.id_viaje
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
			ON e.id_viaje = v.id_viaje
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Compra c
			ON p.id_compra = c.id_compra
			OR e.id_compra = c.id_compra
		WHERE v.id_micro = @id_micro
		AND v.baja = 0
		AND p.baja = 0
		AND e.baja = 0

	open cur_compras

	fetch next from cur_compras into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, 'Baja de micro' 
		fetch next from cur_compras into @idCompraAct 
	END

	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	SET Micros.baja = 1
	WHERE Micros.id_micros = @id_micro
	
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
	SET Butaca.baja = 1
	WHERE Butaca.id_micro = @id_micro
		
	COMMIT TRANSACTION baja_logica_micro
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\34_sp_baja_logica_micro.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\35_sp_insert_marca.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_marca
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
           ([nombre])
     VALUES
           (@p_nombre)
           
           SET @p_id = SCOPE_IDENTITY()
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\35_sp_insert_marca.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\36_sp_insert_servicio.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_servicio
(	@p_tipo_servicio nvarchar(255),
    @p_adicional decimal(5,2),
    @p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
           ([tipo_servicio]
           ,[pocent_adic]
           ,[baja])
     VALUES (@p_tipo_servicio, @p_adicional, 0)

SET @p_id = SCOPE_IDENTITY()
     
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\36_sp_insert_servicio.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\37_sp_listar_filtrado_viaje.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje(
@p_fecha_salida datetime = NULL,
@p_fecha_llegada datetime = NULL,
@p_fecha_llegada_estimada datetime = NULL,
@p_micro int = NULL,
@p_recorrido numeric(18,2) = NULL 
)
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
	 FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
	where ((@p_fecha_salida IS NULL) OR (v.fecha_salida = @p_fecha_salida))
	and ((@p_fecha_llegada IS NULL) OR  (v.fecha_arribo = @p_fecha_llegada))
	and ((@p_fecha_llegada_estimada IS NULL) OR (v.fecha_arribo_estimada = @p_fecha_llegada_estimada ))
	and ((@p_micro IS NULL) OR (v.id_micro = @p_micro))
	and ((@p_recorrido IS NULL) OR (v.id_recorrido = @p_recorrido))
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\37_sp_listar_filtrado_viaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\38_sp_obtener_recorrido.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_recorrido(
	@p_id numeric(18,0)
	)
AS
BEGIN
	SELECT [id_recorrido]
      ,[id_ciudad_origen]
      ,[id_ciudad_destino]
      ,[pre_base_kg]
      ,[pre_base_pasaje]
      ,[id_servicio]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
WHERE id_recorrido = @p_id
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\38_sp_obtener_recorrido.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\39_sp_obtener_micro.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_micro
	@p_id int
AS
BEGIN
	SELECT TOP 1 [id_micros]
      ,[fecha_alta]
      ,[nro_micro]
      ,[modelo]
      ,[patente]
      ,[id_marca]
      ,[id_servicio]
      ,[baja_vida_util]
      ,[fec_baja_vida_util]
      ,[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
  WHERE id_micros = @p_id
END
GO


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\39_sp_obtener_micro.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\40_sp_listar_cliente.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]    Script Date: 07/18/2013 02:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]
AS
BEGIN
	SELECT c.[dni]
      ,c.[nombre]
      ,c.[apellido]
      ,c.[direccion]
      ,c.[telefono]
      ,c.[mail]
      ,c.[fecha_nacimiento]
      ,c.[es_discapacitado]
      ,c.[sexo]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente] c
  WHERE c.baja = 0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\40_sp_listar_cliente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\41_sp_listar_filtrado_cliente.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]    Script Date: 07/18/2013 00:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]
	@p_dni numeric(18,0) = NULL,
	@p_nombre nvarchar(255) = NULL,
	@p_apellido nvarchar(255) = NULL,
	@p_discapacitado CHAR(1) = NULL,
	@p_sexo varchar(50) = NULL
AS
BEGIN
	SELECT [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	where ((@p_dni IS NULL) OR (dni = @p_dni))
	and ((@p_nombre IS NULL) OR (UPPER(nombre) like '%' + UPPER(@p_nombre) +'%'))
	and ((@p_apellido IS NULL) OR (apellido like '%' + @p_apellido + '%'))
	and ((@p_discapacitado IS NULL) OR (ISNULL(es_discapacitado, 'N') = @p_discapacitado))
	and ((@p_sexo IS NULL) OR (ISNULL(sexo, '') = @p_sexo))
	and baja=0
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\41_sp_listar_filtrado_cliente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\42_sp_insert_cliente.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
)
AS
BEGIN
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
           (@p_dni
           ,@p_nombre
           ,@p_apellido
           ,@p_direccion
           ,@p_telefono
           ,@p_mail
           ,@p_fecha_nacimiento
           ,@p_es_discapacitado
           ,@p_sexo)
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\42_sp_insert_cliente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\43_sp_update_cliente.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
SET [nombre]=@p_nombre
           ,[apellido]=@p_apellido
           ,[direccion]=@p_direccion
           ,[telefono]=@p_telefono
           ,[mail]=@p_mail
           ,[fecha_nacimiento]=@p_fecha_nacimiento
           ,[es_discapacitado]=@p_es_discapacitado
           ,[sexo]=@p_sexo
WHERE [dni]=@p_dni
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\43_sp_update_cliente.sql'
PRINT 'MEDIO DEL SCRIPT'
PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\44.sp_listar_filtrado_recompensa.sql'
GO 
USE [GD1C2013]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recompensa]
	@p_descrip nvarchar(200),
	@p_puntos_desde int,
	@p_puntos_hasta int,
	@p_stock_desde int,
	@p_stock_hasta int
AS
BEGIN
	SELECT
		id_recompensa,
		descripcion,
		stock,
		puntos_costo
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recompensa
	WHERE((@p_descrip IS NULL) OR (UPPER(descripcion) LIKE '%'  + UPPER(@p_descrip) + '%'))
	AND ((@p_puntos_desde IS NULL) OR (puntos_costo >= @p_puntos_desde))
	AND ((@p_puntos_hasta IS NULL) OR (puntos_costo <= @p_puntos_hasta))
	AND ((@p_stock_desde IS NULL) OR (stock >= @p_stock_desde))
	AND ((@p_stock_hasta IS NULL) OR (stock <= @p_stock_hasta))
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\44.sp_listar_filtrado_recompensa.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\45_sp_Puntos_por_cliente.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_puntos_por_cliente]
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\45_sp_Puntos_por_cliente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\46_sp_Puntos_por_cliente_detallado.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_puntos_por_cliente_detallado
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT p.dni,
	(p.puntos) as 'puntosOtorgados',
	(p.puntos_usados) as 'puntosUtilizados', 
	(p.puntos - p.puntos_usados) as 'puntosRestantes',
	(p.fecha_otorgado)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	ORDER BY p.fecha_otorgado ASC
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\46_sp_Puntos_por_cliente_detallado.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\47_sp_canjear_recompensa.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_canjear_recompensa
(
	@p_dni numeric(18,0),
	@p_id_recompensa int,
	@p_cantidad	int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION canje_recompensa
	
	DECLARE @puntos_costo int
	DECLARE @puntos_act int
	DECLARE @puntos_usados_act int
	DECLARE @stock_check int
	
	SELECT @puntos_costo = (r.puntos_costo * @p_cantidad)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	SELECT @stock_check=r.stock
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	IF ( @stock_check - @p_cantidad ) < 0
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay stock suficiente', 12, 2)
	END
	
	UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Recompensa
	SET stock = stock - @p_cantidad
	WHERE id_recompensa = @p_id_recompensa

	DECLARE CUR_PUNTAJE CURSOR FOR
		SELECT p.puntos, p.puntos_usados
		FROM [SI_NO_APROBAMOS_HAY_TABLA].Puntaje p
		WHERE p.dni = @p_dni
		AND DATEDIFF(year, p.fecha_otorgado, GETDATE()) < 1
		AND (p.puntos -  p.puntos_usados) >0 
		AND baja = 0
		ORDER BY p.fecha_otorgado ASC
		FOR UPDATE OF p.puntos_usados
	
	SET NOCOUNT ON	
	OPEN CUR_PUNTAJE
	FETCH NEXT FROM CUR_PUNTAJE 
	INTO @puntos_act, @puntos_usados_act
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@puntos_act - @puntos_usados_act) > @puntos_costo
		BEGIN
			--Hay puntos suficientes aca
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos_usados + @puntos_costo
			WHERE CURRENT OF CUR_PUNTAJE
			SET @puntos_costo = 0
			BREAK 
		END
		ELSE
		BEGIN
			--todavia no hay puntos suficientes en esta linea
			SET @puntos_costo = @puntos_costo - (@puntos_act - @puntos_usados_act)
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos
			WHERE CURRENT OF CUR_PUNTAJE
		END
		
		FETCH NEXT FROM CUR_PUNTAJE 
		INTO @puntos_act, @puntos_usados_act
	END	
	
	IF @puntos_costo = 0
	BEGIN
		COMMIT TRANSACTION canje_recompensa
	END
	ELSE
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay suficientes puntos', 12, 2)
	END
	
	CLOSE CUR_PUNTAJE
	DEALLOCATE CUR_PUNTAJE
END
GO



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\47_sp_canjear_recompensa.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\48_sp_clientes_mas_puntos.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_clientes_mas_puntos]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT TOP 5 p.dni, SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE p.fecha_otorgado BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\48_sp_clientes_mas_puntos.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\49_sp_mas_funcion_top5destinosmasvendidos.sql'
GO 
GO
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje
(
	@id_viaje int
)
RETURNS int
BEGIN
	DECLARE @butacas_vendidas_x_viaje int
	SELECT @butacas_vendidas_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
		INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[pasaje] AS pasaje
			ON viaje.id_viaje=pasaje.id_viaje
	WHERE viaje.id_viaje=@id_viaje AND pasaje.id_cancelacion IS NULL
	RETURN @butacas_vendidas_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_mas_vendido_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) AS butacas_vendidas
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) desc
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\49_sp_mas_funcion_top5destinosmasvendidos.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\50_sp_micros_mas_baja_serv.sql'
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_micros_mas_baja_serv]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	
	DECLARE @id_micro int
	DECLARE @patente nvarchar(50)
	DECLARE @fec_fuera datetime
	DECLARE @fec_reinic datetime

	DECLARE CUR CURSOR FOR
		SELECT	bsm.id_micros,
				m.patente,
				bsm.fec_fuera_servicio,
				ISNULL(bsm.fec_reinicio_servicio, GETDATE()) as 'fec_reinicio_servicio'
		FROM SI_NO_APROBAMOS_HAY_TABLA.baja_servicio_micro bsm
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
			ON m.id_micros = bsm.id_micros

	
	CREATE TABLE #tmpDias (
		id_micro		int,
		patente			nvarchar(50),
		dias			int
	)
	
	
	SET NOCOUNT ON
	OPEN CUR
	FETCH NEXT FROM CUR
	INTO @id_micro, @patente, @fec_fuera, @fec_reinic
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--Todos estos if son mutuamente exclusivos
		
		IF @fec_fuera >= @fecha_inicio AND
			@fec_fuera < @fecha_fin	AND
			@fec_reinic <= @fecha_fin AND
			@fec_reinic > @fecha_fin
		BEGIN
			--Arranca y termina dentro del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fec_reinic)))
		END
		 
		IF @fec_fuera < @fecha_inicio AND
			@fec_fuera < @fecha_fin	AND
			@fec_reinic <= @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca antes del periodo pero termina dentro
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fecha_inicio, @fec_reinic)))				
		END
		
		IF @fec_fuera < @fecha_inicio AND 
			@fec_fuera < @fecha_fin AND
			@fec_reinic > @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca antes del periodo y termina despues del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fecha_inicio, @fecha_fin)))			
		END
		
		IF @fec_fuera >= @fecha_inicio AND
			@fec_fuera < @fecha_fin AND
			@fec_reinic > @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca dentro del periodo pero termina despues
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fecha_fin)))
		END
		
		FETCH NEXT FROM CUR
		INTO @id_micro, @patente, @fec_fuera, @fec_reinic
	END
	
	CLOSE CUR
	DEALLOCATE CUR
	
	SELECT TOP 5 tmp.id_micro, tmp.patente, SUM(tmp.dias) as 'diastot'
	FROM #tmpDias tmp 
	GROUP BY tmp.id_micro, tmp.patente
	ORDER BY diastot DESC
	
	DROP TABLE #tmpDias
END














PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\50_sp_micros_mas_baja_serv.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\51_sp_top5_destinos_mas_cancelados_por_semestre.sql'
GO 
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_pasajes_cancelados_x_viaje int
	
	SELECT @cant_pasajes_cancelados_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] AS pasaje
	WHERE pasaje.id_viaje=@id_viaje
			AND pasaje.id_cancelacion IS NOT NULL
	
	RETURN @cant_pasajes_cancelados_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destinos_mas_cancelados_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) AS pasajes_cancelados
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] AS ciudad
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] AS recorrido
			ON ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
			ON viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) DESC
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\51_sp_top5_destinos_mas_cancelados_por_semestre.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\52_sp_top5_destinos_mas_micros_vacios_por_semestre.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_micros_mas_vacios_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(viaje.[id_viaje])) AS butacas_libres_x_viaje
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(viaje.[id_viaje])) desc
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\52_sp_top5_destinos_mas_micros_vacios_por_semestre.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\53.sp_precio_final_pasaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_precio_final_pasaje
(
	@dni numeric(18,0),
	@id_recorrido numeric(18,0)
)
AS
BEGIN
	DECLARE @pre_base numeric(18,2)
	DECLARE @porcent_adic decimal(5,2)
	DECLARE @pre_final numeric(18,2)
	DECLARE @edad int
	DECLARE @sexo varchar(50) 
	DECLARE @discapacitado char(1)
	
	SELECT @pre_base = r.pre_base_pasaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	WHERE r.id_recorrido = @id_recorrido

	SELECT @porcent_adic = s.pocent_adic
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		ON r.id_servicio = s.id_servicio
	WHERE r.id_recorrido = @id_recorrido
	
	SET @pre_final = @pre_base + (@pre_base * @porcent_adic) / 100
	
	SELECT @edad=(DATEDIFF(YEAR, ISNULL(c.fecha_nacimiento, GETDATE()) , GETDATE())), 
		@sexo=ISNULL(c.sexo, 'H'),
		@discapacitado = ISNULL(c.es_discapacitado, 'N')
	FROM SI_NO_APROBAMOS_HAY_TABLA.Cliente c
	WHERE c.dni = @dni
	
	IF @discapacitado = 'S'
	BEGIN
		SELECT 0 as 'precio'
		RETURN
	END
	
	IF @sexo = 'H' AND @edad > 64
	BEGIN
		SELECT @pre_final / 2 as 'precio'
		RETURN
	END
	
	IF @sexo = 'M' AND @edad > 59
	BEGIN
		SELECT @pre_final / 2 as 'precio'
		RETURN
	END
	
	SELECT @pre_final as 'precio'
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\53.sp_precio_final_pasaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\54.sp_butacas_ocupadas_viaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_ocupadas_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso, b.id_micro
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	ON b.id_butaca = p.id_butaca
	WHERE p.id_viaje = @p_id_viaje
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\54.sp_butacas_ocupadas_viaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\55.sp_butacas_libres_viaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_libres_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON m.id_micros = b.id_micro
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @p_id_viaje
	AND b.id_butaca NOT IN
		(
			SELECT b.id_butaca
			FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
				ON b.id_butaca = p.id_butaca
			WHERE p.id_viaje = @p_id_viaje	
		)
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\55.sp_butacas_libres_viaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\56_func_cant_butacas_disp_viaje.sql'
GO 

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_total int
	DECLARE @cant_ocupadas int
	DECLARE @id_micro int
	
	SELECT @id_micro=m.id_micros, @cant_total=COUNT(b.id_butaca)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON v.id_micro = m.id_micros
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON b.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	GROUP BY v.id_viaje, m.id_micros
	
	SELECT @cant_ocupadas=COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
		ON p.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	return @cant_total - @cant_ocupadas
END
GO

GO 
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje
(
	@id_viaje int
)
RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @kg_totales numeric(18,0)
	DECLARE @kg_ocupados numeric(18,0)
	
	SELECT @kg_totales=m.capacidad_kg
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Micros m
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	
	SELECT @kg_ocupados=SUM(e.peso)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Encomienda e
		ON e.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	RETURN @kg_totales - @kg_ocupados
		
END


GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_micro_disponibilidades
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje(@p_id_viaje) as kgs,
	[SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(@p_id_viaje) as butacas
	
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\58_sp_obtener_micro_disponibilidades.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\59.sp_precio_final_pasaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_precio_real_pasaje
(
	@dni numeric(18,0),
	@id_recorrido numeric(18,0)
)
AS
BEGIN
	DECLARE @pre_base numeric(18,2)
	DECLARE @porcent_adic decimal(5,2)
	DECLARE @pre_final numeric(18,2)
	DECLARE @edad int
	DECLARE @sexo varchar(50) 
	DECLARE @discapacitado char(1)
	
	SELECT @pre_base = r.pre_base_pasaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	WHERE r.id_recorrido = @id_recorrido

	SELECT @porcent_adic = s.pocent_adic
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		ON r.id_servicio = s.id_servicio
	WHERE r.id_recorrido = @id_recorrido
	
	SET @pre_final = @pre_base + (@pre_base * @porcent_adic) / 100
	
	SELECT @edad=(DATEDIFF(YEAR, ISNULL(c.fecha_nacimiento, GETDATE()) , GETDATE())), 
		@sexo=ISNULL(c.sexo, 'H'),
		@discapacitado = ISNULL(c.es_discapacitado, 'N')
	FROM SI_NO_APROBAMOS_HAY_TABLA.Cliente c
	WHERE c.dni = @dni
	
	IF @discapacitado = 'S'
	BEGIN
		SELECT 0 as 'precio'
		RETURN
	END
	
	IF @sexo = 'H' AND @edad > 64
	BEGIN
		SELECT @pre_final / 2 as 'precio'
		RETURN
	END
	
	IF @sexo = 'M' AND @edad > 59
	BEGIN
		SELECT @pre_final / 2 as 'precio'
		RETURN
	END
	
	SELECT @pre_final as 'precio'
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\59.sp_precio_final_pasaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\60.sp_insertar_compra.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_compra
(	
	@p_id_compra int output,
	@p_id_usuario int,
	@p_fecha_compra datetime
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Compra
		(id_usuario, fecha_compra)
	VALUES
		(@p_id_usuario, @p_fecha_compra)

	SET @p_id_compra = SCOPE_IDENTITY()
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\60.sp_insertar_compra.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\61.sp_existe_patente.sql'
GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_existe_patente
(
	@p_patente nvarchar(50)
)
AS
BEGIN
	SELECT COUNT(*) as 'cant'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros
	WHERE patente = @p_patente
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\61.sp_existe_patente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\62.sp_insertar_encomienda.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insertar_encomienda]    Script Date: 07/21/2013 03:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insertar_encomienda]
(
	@p_id_encomienda int output,
	@p_id_compra int,
	@p_dni numeric(18,0),
	@p_pre_encomienda int,
	@p_id_viaje int,
	@p_peso numeric(18,0)
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Encomienda
		(id_viaje, id_compra, dni, pre_encomienda, peso)
	VALUES
		(@p_id_viaje,@p_id_compra, @p_dni, @p_pre_encomienda, @p_peso)

	SET @p_id_encomienda = SCOPE_IDENTITY()
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\62.sp_insertar_encomienda.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\63.sp_insertar_pasaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_pasaje
(
	@p_id_pasaje int output,
	@p_id_compra int,
	@p_id_butaca int,
	@p_dni numeric(18,0),
	@p_pre_pasaje int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Pasaje
		(id_compra, id_butaca, dni, pre_pasaje, id_viaje)
	VALUES
		(@p_id_compra, @p_id_butaca, @p_dni, @p_pre_pasaje, @p_id_viaje)

	SET @p_id_pasaje = SCOPE_IDENTITY()
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\63.sp_insertar_pasaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\64_sp_listar_compras.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_compras
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
      --,[cancel]
      --,[fecha_cancel]
      --,ISNULL([motivo_cancel], '') as motivo_cancel
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE [baja] = 0
END




PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\64_sp_listar_compras.sql'


PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\66_SP_cancel_pasaje.sql'
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_pasaje
	@id_pasaje	numeric(18,0),
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_pasaje = @id_pasaje
	
	COMMIT TRANSACTION cancel
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\66_SP_cancel_pasaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\67_SP_cancel_encomienda.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_encomienda
	@id_encomienda	numeric(18,0),
	@motivo			nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_encomienda= @id_encomienda
	
	COMMIT TRANSACTION cancel
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\67_SP_cancel_encomienda.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\68_sp_listar_cancelaciones.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_cancelaciones
AS
BEGIN
SELECT [id_cancelacion]
      ,[fecha_cancel]
      ,[motivo_cancel]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion]
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\68_sp_listar_cancelaciones.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\69_sp_reemplazar_futuros_por_otro_micro.sql'
GO 

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde
(
	@id_micro_candidato int,
	@fechaInic datetime
)
RETURNS bit 
BEGIN
	IF (
		SELECT COUNT(v.id_viaje) 
		FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON m.id_micros = v.id_micro
		WHERE m.id_micros = @id_micro_candidato
		AND v.fecha_salida >= @fechaInic
	) > 0
	BEGIN
		RETURN 0
	END
	RETURN 1
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_reemplazar_futuros_por_otro_micro
(
	@id_micro int,
	@id_micro_nuevo int output
)
AS
BEGIN
	DECLARE @modelo nvarchar(50)
	DECLARE @idMarca int
	DECLARE @microElegido int
	
	SELECT @modelo=m.modelo, @idMarca=m.id_marca
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.id_micros = @id_micro
	
	SELECT TOP 1 @microElegido=m.id_micros 
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.modelo = @modelo
	AND m.id_marca = @idMarca
	AND [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde(m.id_micros, GETDATE()) = 1
	AND m.id_micros <> @id_micro
	AND m.baja = 0
	
	IF @microElegido is not null
	BEGIN
		UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
		SET id_micro = @microElegido
		WHERE id_micro = @id_micro
		AND fecha_salida >= GETDATE()
		SET @id_micro_nuevo = @microElegido
	END
	ELSE
	BEGIN
		SET @id_micro_nuevo = 0
	END
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\69_sp_reemplazar_futuros_por_otro_micro.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\70_sp_insertar_usuario.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_usuario
(
	@dni numeric(18,0),
	@username nvarchar(50)
)
AS
BEGIN	
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Usuario
		(id_rol, dni, username)
	VALUES (2, @dni, @username)
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\70_sp_insertar_usuario.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\71_sp_obtener_usuario_por_dni.sql'
GO 
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario_por_dni](

	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT 
		[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where dni = @p_dni
END
GO

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\71_sp_obtener_usuario_por_dni.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\72_sp_obtener_compra.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_compra
(
	@p_id int
)
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
      --,[cancel]
      --,[fecha_cancel]
      --,ISNULL([motivo_cancel], '') as motivo_cancel
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE id_compra = @p_id
END




PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\72_sp_obtener_compra.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\73_sp_insert_viaje.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]    Script Date: 07/18/2013 21:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]
(
	@p_id_recorrido numeric(18,0),
	@p_id_micro int,
	@p_fecha_salida datetime,
	@p_fecha_arribo_estimada datetime,
	@p_id int output
)
AS
BEGIN

	IF (@p_fecha_salida > GETDATE())
	BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
           ([id_recorrido]
           ,[id_micro]
           ,[fecha_salida]
           ,[fecha_arribo_estimada]
          )
	VALUES
           (@p_id_recorrido,
           @p_id_micro,
           @p_fecha_salida,
           @p_fecha_arribo_estimada
           )
           
	SET @p_id = SCOPE_IDENTITY()
	END
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\73_sp_insert_viaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\74_sp_registro_llegada.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_registro_llegada]
(
	@p_id_viaje int,
	@p_fecha_llegada datetime
)
AS
BEGIN
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].[ArribosTemporal]
           ([Id_viaje]
           ,[Fecha_arribo_real])
     VALUES
           (@p_id_viaje, @p_fecha_llegada)
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\74_sp_registro_llegada.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\75_sp_update_rol.sql'
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_rol]    Script Date: 07/16/2013 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_rol](
	@p_nombre varchar(50),
	@p_id int,
	@p_inhabilitado bit
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Rol
	SET nombre = @p_nombre,
		inhabilitado = @p_inhabilitado
	WHERE id_rol = @p_id
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\75_sp_update_rol.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\76_sp_update_viaje.sql'
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_viaje]
	@p_Fecha_Salida datetime,
	@p_Fecha_Arribo_Estimada datetime,
	@p_id_micro int,
	@p_id_recorrido int,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
   SET [id_recorrido] = @p_id_recorrido
      ,[id_micro] = @p_id_micro
      ,[fecha_salida] = @p_Fecha_Salida
      ,[fecha_arribo_estimada] = @p_Fecha_Arribo_Estimada 
 WHERE id_viaje = @p_id
END



PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\76_sp_update_viaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\77_sp_delete_cliente.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_cliente
(
	@p_dni int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	SET baja=1			
	WHERE Cliente.dni=@p_dni
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\77_sp_delete_cliente.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\78_sp_delete_viaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_viaje
(
	@p_id int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
	SET baja=1			
	WHERE id_viaje=@p_id
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\78_sp_delete_viaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\79_sp_listar_detallado_encomienda.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_detallado_encomienda
(
	@p_dni numeric(18,0),
	@p_id_encomienda int,
	@p_id_viaje int,
	@p_id_compra int,
	@p_kgs numeric(18,2)
)
AS
BEGIN
	SELECT e.id_encomienda
	, e.id_viaje
	, e.id_compra
	,ISNULL(e.id_cancelacion, 0) as id_cancelacion
	, e.dni
	, e.peso
	, e.pre_encomienda
	--,e.cancel
	--,e.fecha_cancel
	--,e.motivo_cancel
	, e.baja
	FROM SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON e.id_viaje = v.id_viaje
	WHERE ((@p_dni is null) OR (@p_dni=e.dni))
	AND ((@p_id_encomienda is null) OR (e.id_encomienda = @p_id_encomienda))
	AND ((@p_id_viaje IS NULL) OR (e.id_viaje = @p_id_viaje))
	AND ((@p_id_compra IS NULL) OR (e.id_compra = @p_id_compra))
	AND ((@p_kgs IS NULL) OR (e.peso = @p_kgs))
	
END


PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\79_sp_listar_detallado_encomienda.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\80_sp_listar_detallado_pasaje.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_detallado_pasaje
(
	@p_id_micro int,
	@p_dni numeric(18,0),
	@p_id_butaca int,
	@p_precio numeric(18,2)
)
AS
BEGIN
	SELECT p.id_pasaje
	, p.id_compra
	, p.id_butaca
	,p.id_cancelacion
	, p.dni
	, p.pre_pasaje
	,p.disponible
	--, p.cancel
	--, p.fecha_cancel
	--,p.motivo_cancel
	, p.id_viaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON p.id_butaca = b.id_butaca
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON b.id_micro = m.id_micros
	WHERE ((@p_id_micro is null) OR (m.id_micros = @p_id_micro))
	AND ((@p_dni is null) OR (p.dni = @p_dni))
	AND ((@p_id_butaca IS NULL) OR (p.id_butaca = @p_id_butaca))
	AND ((@p_precio IS NULL) OR (p.pre_pasaje = @p_precio))
	
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\80_sp_listar_detallado_pasaje.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\81_sp_procesar_arribos.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_procesar_arribos
AS
BEGIN
	DECLARE @id_viaje int
	DECLARE @fecha_arribo_real datetime
	
	DECLARE Cursor_arribos Cursor FOR
		SELECT Id_viaje, Fecha_arribo_real
		FROM SI_NO_APROBAMOS_HAY_TABLA.ArribosTemporal
	
	OPEN Cursor_arribos
	
	BEGIN TRY
		BEGIN TRAN
			
			Fetch NEXT FROM Cursor_arribos INTO @id_viaje, @fecha_arribo_real
			While (@@FETCH_STATUS <> -1)
			BEGIN
				UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
				SET fecha_arribo = @fecha_arribo_real
				WHERE id_viaje = @id_viaje	
				
				FETCH NEXT FROM Cursor_arribos INTO @id_viaje, @fecha_arribo_real
			END 
		COMMIT
	END TRY
	BEGIN CATCH 
		ROLLBACK
	END CATCH	
	CLOSE Cursor_arribos
	DEALLOCATE Cursor_arribos
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\81_sp_procesar_arribos.sql'

PRINT 'Inicio de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\83.sp_filtrar_compras.sql'
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_filtrar_compras
(
	@id_compra int = NULL,
	@dni numeric(18,0) = NULL,
	@fecha_compra datetime = NULL
)
AS
BEGIN
SELECT c.[id_compra]
      ,c.[id_usuario]
      ,ISNULL(c.[id_cancelacion], 0) as id_cancelacion
      ,c.[fecha_compra]
  FROM [SI_NO_APROBAMOS_HAY_TABLA].[Compra] c
	inner join SI_NO_APROBAMOS_HAY_TABLA.Usuario u
		on c.id_usuario = u.id_usuario
	inner join SI_NO_APROBAMOS_HAY_TABLA.Cliente cli
		on u.dni = cli.dni
	AND ((@dni is null) OR (cli.dni = @dni) )
	AND ((@id_compra is null) OR (c.id_compra = @id_compra))
	AND ((@fecha_compra is null) OR (c.fecha_compra = @fecha_compra))
END

PRINT 'Fin de sp: C:\GDD_Sources\TP1C2013 K3051 SI_NO_APROBAMOS_HAY_TABLA 16 ZIP123\data\Finales\01 - SELECT\83.sp_filtrar_compras.sql'

PRINT 'FIN DEL SCRIPT'