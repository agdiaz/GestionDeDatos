/*===========================SCHEMA=============================*/
USE [GD1C2013]
GO

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'SI_NO_APROBAMOS_HAY_TABLA')
DROP SCHEMA [SI_NO_APROBAMOS_HAY_TABLA]

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

USE [GD1C2013]
GO

/****** Object:  Index [indice_recorrido_ciudad]    Script Date: 07/14/2013 11:45:15 ******/
CREATE NONCLUSTERED INDEX [indice_recorrido_ciudad] ON [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] 
(
	[id_ciudad_destino] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/*===========================MICROS==============================*/

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

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ADD  CONSTRAINT [DF_Compra_cancel]  DEFAULT ((0)) FOR [cancel]
GO

ALTER TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Compra] ADD  CONSTRAINT [DF_Compra_baja]  DEFAULT ((0)) FOR [baja]
GO

/*===========================PASAJE==============================*/

USE [GD1C2013]
GO

/****** Object:  Table [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje]    Script Date: 06/21/2013 01:48:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje](
	[id_pasaje] [numeric](18, 0) NOT NULL,
	[id_compra] [int] NOT NULL,
	[nro_butaca] [numeric](18,0) NOT NULL,
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
BEGIN TRANSACTION comprasPasajes
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

INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Pasaje
(id_pasaje, id_compra, nro_butaca, dni, pre_pasaje, id_viaje)
(
	select	m.codPasaje		as id_pasaje,
			m.ident			as id_compra,
			m.butaca_nro	as nro_butaca,
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
)
DROP TABLE #tmpPasajes


USE [GD1C2013]
GO

/****** Object:  Index [indice_pasaje_viaje]    Script Date: 07/14/2013 11:44:10 ******/
CREATE NONCLUSTERED INDEX [indice_pasaje_viaje] ON [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] 
(
	[id_viaje] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

COMMIT TRANSACTION comprasPasajes

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

SET IDENTITY_INSERT SI_NO_APROBAMOS_HAY_TABLA.Compra ON

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
COMMIT TRANSACTION comprasEncomiendas

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
values ('tsmClientePasajeroFrecuenteConsultar')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmViajeAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmViajeListado')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmPasajeEncomiendaAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmPasajeEncomiendaCancelar')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmEstadisticasT5ClientesMasPuntos')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmEstadisticasT5DestMasCancelados')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmEstadisticasT5DestMasMicrosVacios')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmEstadisticasT5DestMasVendidos')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmEstadisticasT5MicrosMasDiasFueraDeServicio')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmPremiosAlta')

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad](funcionalidad)
values ('tsmPremiosListado')

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
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClientePasajeroFrecuenteConsultar'

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
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5ClientesMasPuntos'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5DestMasCancelados'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5DestMasMicrosVacios'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5DestMasVendidos'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5MicrosMasDiasFueraDeServicio'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPremiosAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPremiosListado'

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

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Puntaje]
	([dni],[id_compra],[puntos],[puntos_usados])
VALUES (27223299,145098,103,0)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Puntaje]
	([dni],[id_compra],[puntos],[puntos_usados])
VALUES (12835515,139822,103,0)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Puntaje]
	([dni],[id_compra],[puntos],[puntos_usados])
VALUES (74978796,219895,92,0)

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

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Canje]
	([dni],[id_recompensa])
VALUES (27223299, 3) --restar 10

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Canje]
	([dni],[id_recompensa])
VALUES (12835515, 4) --restar 100

UPDATE SI_NO_APROBAMOS_HAY_TABLA.Puntaje
SET puntos_usados = 10
WHERE id_puntaje = 1

UPDATE SI_NO_APROBAMOS_HAY_TABLA.Puntaje
SET puntos_usados = 100
WHERE id_puntaje = 2
	   
/*===========================FUNCION BUTACAS X MICRO==============================*/
GO
CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_por_micro
(
	@p_id_micro int 
)
RETURNS int
AS
BEGIN
	DECLARE @cantidad int

SELECT @cantidad = COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	WHERE b.id_micro = @p_id_micro
	AND b.baja = 0
	
	RETURN @cantidad

END
GO
/*===========================FUNCION BUTACAS VENDIDAS==============================*/

CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_vendidas
(
	@p_id_viaje int 
)
RETURNS int
AS
BEGIN

DECLARE @cantidad int
	SELECT @cantidad = COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	WHERE p.id_viaje = @p_id_viaje
	AND p.cancel = 0
	AND p.baja = 0

	RETURN @cantidad

END
GO
/*===========================FUNCION KG VENDIDOS==============================*/

CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.f_obtener_kg_vendidos
(
	@p_id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @total numeric(18,0)
	SELECT @total = SUM(e.peso)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
	where @p_id_viaje = e.id_viaje
	and e.baja = 0

	RETURN @total

END
GO
/*===========================FUNCION SELECCION FUNCIONALIDADES==============================*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].obtener_funcionalidades_rol
	@nombre_rol nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT f.funcionalidad
	FROM SI_NO_APROBAMOS_HAY_TABLA.Funcionalidad f
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol_funcionalidad rf
		ON rf.id_funcionalidad = f.id_funcionalidad
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol r
		ON rf.id_rol = r.id_rol
	WHERE r.nombre = @nombre_rol
	AND f.baja = 0
	AND r.baja = 0
	AND rf.baja = 0
END
GO

/*===========================FUNCION OBTENER ROL==============================*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].obtener_rol 
	-- Add the parameters for the stored procedure here
	@userName nvarchar(50),
	@rol nvarchar(50) OUTPUT
	
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT @rol=r.nombre
	FROM SI_NO_APROBAMOS_HAY_TABLA.Rol r
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Usuario u
	ON u.id_rol = r.id_rol
	WHERE u.username = @userName
	AND u.baja = 0
	AND r.baja = 0
END
GO

/*===========================FUNCION IDENTIFICAR USUARIOS Y GRABAR INTENTOS FALLIDOS==============================*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	AND us.baja = 0
	
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

/*===========================SP LISTAR CIUDAD==============================*/


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_ciudad 
AS
BEGIN
	SELECT c.[id_ciudad], c.[nombre]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] c
	WHERE c.baja = 0
END
GO
/*===========================SP LISTAR FILTRADO CIUDAD==============================*/

GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_ciudad 
	@p_ciudad varchar(50) = NULL
AS
BEGIN
	SELECT c.[id_ciudad],c.[nombre]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] c
	where ((@p_ciudad IS NULL) OR (c.nombre = @p_ciudad))	
	and c.baja = 0
END
GO
/*===========================SP LISTAR MARCA==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_marca
AS
BEGIN
SELECT m.[id_marca],m.[nombre]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca] m
  WHERE m.baja = 0
END
GO
/*===========================SP LISTAR CLIENTE==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_cliente
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
GO
/*===========================SP LISTAR FILTRADO CLIENTE==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_cliente
	@p_dni numeric(18,0) = NULL,
	@p_nombre nvarchar(255) = NULL,
	@p_apellido nvarchar(255) = NULL
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
	where ((@p_dni IS NULL) OR (@p_dni = c.dni))
	and ((@p_nombre IS NULL) OR (@p_nombre = c.nombre))
	and ((@p_apellido IS NULL) OR (@p_apellido = c.apellido))
	and c.baja = 0
END
GO
/*===========================SP LISTAR SERVICIO==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_servicio
AS
BEGIN
	SELECT s.[id_servicio]
      ,s.[tipo_servicio]
      ,s.[pocent_adic]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio] s
  WHERE s.baja = 0
END
GO
/*===========================SP LISTAR FILTRADO RECORRIDO==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_recorrido
	@p_ciudad_origen varchar(50) = NULL,
	@p_ciudad_destino varchar(50) = NULL, 
	@p_tipo_servicio nvarchar(255) = NULL
	AS
BEGIN
	SELECT distinct r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
      ,r.[baja]
      ,cOrigen.nombre
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
	left join SI_NO_APROBAMOS_HAY_TABLA. Ciudad cOrigen
		on r.id_ciudad_origen = cOrigen.id_ciudad and cOrigen.nombre = @p_ciudad_origen
	left join SI_NO_APROBAMOS_HAY_TABLA. Ciudad cDestino
		on r.id_ciudad_destino = cDestino.id_ciudad and cDestino.nombre = @p_ciudad_destino	
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on r.id_servicio = s.id_servicio 
	where ((@p_ciudad_origen IS NULL) OR (cOrigen.nombre = @p_ciudad_origen))
	and ((@p_ciudad_destino IS NULL) OR (cDestino.nombre = @p_ciudad_destino))
	and ((@p_tipo_servicio IS NULL) OR (@p_tipo_servicio = s.tipo_servicio))
	and r.baja = 0
	and cOrigen.baja = 0
	and cDestino.baja = 0
END
GO
/*===========================SP LISTAR RECORRIDO==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_recorrido
	AS
BEGIN
	SELECT r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
  WHERE r.baja = 0
END
GO
/*===========================SP LISTAR FILTRADO MICROS==============================*/
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
      ,m.[baja_fuera_servicio]
      ,m.[baja_vida_util]
      ,m.[fec_fuera_servicio]
      ,m.[fec_reinicio_servicio]
      ,m.[fec_baja_vida_util]
      ,m.[capacidad_kg]
      ,m.[baja]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] m
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on s.id_servicio = m.id_servicio and @p_tipo_servicio = s.tipo_servicio
	left join SI_NO_APROBAMOS_HAY_TABLA.Marca ma
		on ma.id_marca = m.id_marca and @p_marca = ma.nombre
	where ((@p_modelo IS NULL) OR (@p_modelo = m.modelo))
	and ((@p_patente IS NULL) OR (@p_patente = m.patente))
	and ((@p_nro_micro IS NULL) OR (@p_nro_micro = m.nro_micro))
	and ((@p_kgs_encomienda IS NULL) OR (@p_kgs_encomienda = m.capacidad_kg))
	and m.baja = 0
	and s.baja = 0
	and ma.baja = 0

END
GO
/*===========================SP LISTAR MICROS==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_micros
AS
BEGIN
	SELECT m.[id_micros]
      ,m.[fecha_alta]
      ,m.[nro_micro]
      ,m.[modelo]
      ,m.[patente]
      ,m.[id_marca]
      ,m.[id_servicio]
      ,m.[baja_fuera_servicio]
      ,m.[baja_vida_util]
      ,m.[fec_fuera_servicio]
      ,m.[fec_reinicio_servicio]
      ,m.[fec_baja_vida_util]
      ,m.[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] m
  WHERE m.baja = 0
END
GO
/*===========================SP LISTAR BUTACA==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_butaca
	AS
BEGIN
	SELECT b.[id_butaca]
      ,b.[nro_butaca]
      ,b.[id_micro]
      ,b.[tipo_butaca]
      ,b.[piso]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca] b
  WHERE b.baja = 0
END
GO
/*===========================SP LISTAR FILTRADO VIAJE==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje
@p_fecha_salida datetime = NULL,
@p_fecha_llegada datetime = NULL,
@fecha_llegada_estimada datetime = NULL,
@p_micro int = NULL,
@p_recorrido numeric(18,2) = NULL 
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
      ,v.[baja]
	 FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
	where ((@p_fecha_salida IS NULL) OR (@p_fecha_salida = v.fecha_salida))
	and ((@p_fecha_llegada IS NULL) OR (@p_fecha_llegada = v.fecha_arribo))
	and ((@fecha_llegada_estimada IS NULL) OR (@fecha_llegada_estimada = v.fecha_arribo_estimada))
	and ((@p_micro IS NULL) OR (@p_micro = v.id_micro))
	and ((@p_recorrido IS NULL) OR (@p_recorrido = v.id_recorrido))
	and v.baja = 0
END
GO
/*===========================SP LISTAR VIAJE==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viaje
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
      ,v.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
END
GO
/*===========================SP LISTAR FILTRADO ROL==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_rol
	@p_rol nvarchar(50) = NULL, @p_funcionalidad nvarchar(255) = NULL 
	AS
BEGIN
	SELECT distinct r.id_rol, r.[nombre], r.inhabilitado
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] r
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Rol_Funcionalidad rf
		on r.id_rol = rf.id_rol
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Funcionalidad f
		on rf.id_funcionalidad = f.id_funcionalidad
	where ((@p_rol IS NULL) OR (r.nombre = @p_rol))
	and ((@p_funcionalidad IS NULL) OR (f.funcionalidad = @p_funcionalidad))
	and r.baja = 0
	and rf.baja = 0
END
GO
/*===========================SP LISTAR ROL==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol
	AS
BEGIN
	SELECT r.[id_rol]
      ,r.[nombre]
      ,r.[inhabilitado]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] r
  WHERE r.baja = 0
END
GO
/*===========================SP LISTAR USUARIO==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_usuario 
AS
BEGIN
SELECT u.[id_usuario]
      ,u.[id_rol]
      ,u.[dni]
      ,u.[username]
      ,u.[hash_password]
      ,u.[cant_intentos_fallidos]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario] u
  WHERE u.baja = 0
END
GO
/*===========================SP LISTAR FUNCIONALIDAD==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidad
AS
BEGIN
SELECT f.[id_funcionalidad]
      ,f.[funcionalidad]
      ,f.[activa]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] f
  WHERE f.baja = 0
END
GO
/*===========================SP LISTAR ROL FUNCIONALIDAD==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol_funcionalidad
AS
BEGIN
	SELECT rf.[id_rol]
      ,rf.[id_funcionalidad]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad] rf
  WHERE rf.baja = 0
END
GO
/*===========================SP LISTAR BUSCAR MICROS==============================*/
GO
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_buscar_micros
@p_fecha_salida datetime = NULL,
@p_ciudad_origen int = NULL,
@p_ciudad_destino int = NULL

AS
BEGIN

	SELECT micro.id_micros
	,marca.nombre
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_por_micro(micro.id_micros) as butacas_total
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_vendidas(viaje.id_viaje) as butacas_vendidas
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_por_micro(micro.id_micros)
	- SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_vendidas(viaje.id_viaje) as butacas_disponibles
	,micro.capacidad_kg 
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_kg_vendidos(viaje.id_viaje) as kgs_vendidos
	,micro.capacidad_kg -
	SI_NO_APROBAMOS_HAY_TABLA.f_obtener_kg_vendidos(viaje.id_viaje) as kgs_disponibles
	,servicio.tipo_servicio
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros micro
	-- Micro <--> Marca
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Marca marca
		ON marca.id_marca = micro.id_marca
	-- Micro <--> Servicio
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio servicio
		ON servicio.id_servicio = micro.id_servicio
	-- Micro <--> Viaje
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje viaje
		ON viaje.id_micro = micro.id_micros
		AND  @p_fecha_salida = viaje.fecha_salida
	-- Viaje <--> Recorrido
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Recorrido recorrido
		ON recorrido.id_recorrido = viaje.id_recorrido
		AND @p_ciudad_destino = recorrido.id_ciudad_destino
		AND @p_ciudad_origen = recorrido.id_ciudad_origen
	WHERE micro.baja_fuera_servicio = 0
	AND micro.baja_vida_util = 0
	AND micro.baja = 0
	AND viaje.baja = 0
	AND recorrido.baja = 0
	AND marca.baja = 0
	AND servicio.baja = 0
		
		
END
GO
/*===========================SP BAJA FISICA MICRO==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_fisica_micro
(
	@id_micro int
)
AS
BEGIN
	DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	WHERE Micros.id_micros=@id_micro
END
GO
/*===========================SP BAJA LOGICA MICRO==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	SET Micros.baja = 1
	WHERE Micros.id_micros = @id_micro
END

/*===========================SP BAJA LOGICA RECORRIDO==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_dar_baja_recorrido
(
	@id_recorrido numeric(18,0),
	@baja bit
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
	SET [baja] = @baja
	WHERE @id_recorrido=Recorrido.id_recorrido
END
GO
/*===========================SP BAJA LOGICA ROL==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_rol
(
	@id_rol int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	SET [baja] = 1
	WHERE Rol.id_rol = @id_rol
END
GO
/*===========================SP DELETE CIUDAD==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_delete_ciudad
(
@id_ciudad INT
)
AS
BEGIN
	DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE @id_ciudad=id_ciudad
END

/*===========================SP DELETE CLIENTE==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_cliente
(
	@dni numeric(18,0)
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	SET baja=1			--Se tiene que agregar campo
	WHERE Cliente.dni=@dni
END
GO
/*===========================SP INSERT CIUDAD==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]
(
	@nombre varchar(50),
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@nombre)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT CLIENTE==============================*/
GO
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_cliente
(
	@dni numeric(18,0),
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@direccion nvarchar(255),
	@telefono numeric(18,0),
	@mail nvarchar(255),
	@fecha_nacimiento datetime,
	@es_discapacitado char(1),
	@sexo varchar(50)
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
           (@dni
           ,@nombre
           ,@apellido
           ,@direccion
           ,@telefono
           ,@mail
           ,@fecha_nacimiento
           ,@es_discapacitado
           ,@sexo)
END
GO
/*===========================SP INSERT MICRO==============================*/

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_micro
(
	@fecha_alta datetime2(7),
	@nro_micro int,
	@modelo nvarchar(50),
	@patente nvarchar(50),
	@id_marca int,
	@id_servicio int,
	@baja_fuera_servicio bit,
	@baja_vida_util bit,
	@fec_fuera_servicio datetime,
	@fec_reinicio_servicio datetime,
	@fec_baja_vida_util datetime,
	@capacidad_kg numeric(18,2),
	@baja bit
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
           ,[baja_fuera_servicio]
           ,[baja_vida_util]
           ,[fec_fuera_servicio]
           ,[fec_reinicio_servicio]
           ,[fec_baja_vida_util]
           ,[capacidad_kg]
           ,[baja])
     VALUES
           (@fecha_alta,
           @nro_micro,
           @modelo,
           @patente,
           @id_marca,
           @id_servicio,
           @baja_fuera_servicio,
           @baja_vida_util,
           @fec_fuera_servicio,
           @fec_reinicio_servicio,
           @fec_baja_vida_util,
           @capacidad_kg,
           @baja)
END

/*===========================SP INSERT RECORRIDO==============================*/
GO
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_recorrido
(
	@id_recorrido int,
	@id_ciudad_origen int,
	@id_ciudad_destino int,
	@pre_base_kg numeric(18,2),
	@pre_base_pasaje numeric(18,2),
	@id_servicio int,
	@baja bit
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
           ([id_recorrido]
           ,[id_ciudad_origen]
           ,[id_ciudad_destino]
           ,[pre_base_kg]
           ,[pre_base_pasaje]
           ,[id_servicio]
           ,[baja])
	VALUES
           (@id_recorrido,
           @id_ciudad_origen,
           @id_ciudad_destino,
           @pre_base_kg,
           @pre_base_pasaje,
           @id_servicio,
           @baja)
END
GO
/*===========================SP INSERT ROL==============================*/

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_rol
(
	@nombre nvarchar(50),
	@inhabilitado bit = '0',
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@nombre,@inhabilitado)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT ROL FUNCIONALIDAD==============================*/
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_insert_rol_funcionalidad
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
GO
/*===========================SP INSERT VIAJE==============================*/

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_viaje
(
	@id_recorrido numeric(18,0),
	@id_micro int,
	@fecha_salida datetime,
	@fecha_arribo_estimada datetime,
	@fecha_arribo datetime,
	@baja bit
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
           ([id_recorrido]
           ,[id_micro]
           ,[fecha_salida]
           ,[fecha_arribo_estimada]
           ,[fecha_arribo]
           ,[baja])
	VALUES
           (@id_recorrido,
           @id_micro,
           @fecha_salida,
           @fecha_arribo_estimada,
           @fecha_arribo,
           @baja)
END
GO

/*===========================SP BAJA FUNCIONALIDADES==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_baja_funcionalidades]
(
	@p_id_rol int 
)
AS
BEGIN

DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad]
	WHERE Rol_funcionalidad.id_rol = @p_id_rol
END
GO


/*===========================F BUTACAS VENDIDAS POR VIAJE===========================*/


CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @butacas_vendidas int
	
	SELECT @butacas_vendidas = COUNT(*) 
	FROM [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] AS pasaje 
	WHERE @id_viaje=pasaje.[id_viaje] AND pasaje.baja=0
	
	RETURN isnull(@butacas_vendidas,0)

END
GO

/*===========================Top 5 destinos mas vendidos=============================*/
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_top5_destino_mas_vendido_por_semestre
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
	WHERE recorrido.baja=0 AND viaje.baja=0 AND viaje.fecha_arribo BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) desc
END


/*=============================Update viaje fecha arribo===============================*/
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_update_viaje_fecha_arribo
(
	@patente nvarchar(50),
	@fecha_hora_llegada datetime
)
AS
BEGIN
	DECLARE @micro_id int
	SELECT @micro_id = micros.[id_micros]
				FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] AS micros
				WHERE @patente=micros.patente
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
	SET [fecha_arribo]=@fecha_hora_llegada
	WHERE viaje.id_micro = @micro_id
END
GO



/*===============================================================*/
/*===========================VISTAS==============================*/
/*===============================================================*/
GO

CREATE VIEW [SI_NO_APROBAMOS_HAY_TABLA].v_DestinosMasCancelados
AS
SELECT top 5 Ciudad.nombre, COUNT(id_pasaje) as CantCancelados
from SI_NO_APROBAMOS_HAY_TABLA.Ciudad
inner join SI_NO_APROBAMOS_HAY_TABLA.Recorrido
	on Ciudad.id_ciudad = Recorrido.id_ciudad_destino
inner join SI_NO_APROBAMOS_HAY_TABLA.Viaje
	on Recorrido.id_recorrido = Viaje.id_recorrido
inner join SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	on Pasaje.id_viaje = Viaje.id_viaje
where Pasaje.cancel = 1
and Ciudad.baja = 0
and Recorrido.baja = 0
and Viaje.baja = 0
and Pasaje.baja = 0
group by Viaje.id_viaje, Ciudad.nombre
order by CantCancelados DESC

GO

CREATE VIEW [SI_NO_APROBAMOS_HAY_TABLA].v_MicrosConMasDiasFueraDeServicio
AS
SELECT top 5 Micros.id_micros, DATEDIFF(day,isNull(Micros.fec_fuera_servicio,0),isNull(Micros.fec_reinicio_servicio,0)) as Diferencia
from SI_NO_APROBAMOS_HAY_TABLA.Micros
where Micros.baja = 0
order by Diferencia DESC

GO

/*=============================Micros arribos retrasados===============================*/
CREATE VIEW [SI_NO_APROBAMOS_HAY_TABLA].micros_arribos_retrasados
AS SELECT micro.id_micros, viaje.id_viaje, viaje.fecha_arribo, viaje.fecha_arribo_estimada
FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] AS micro
	inner join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
		ON viaje.id_micro=micro.id_micros
WHERE viaje.fecha_arribo <> viaje.fecha_arribo_estimada AND viaje.baja=0

