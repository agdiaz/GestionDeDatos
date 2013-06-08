USE [GD1C2013]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 06/08/2013 13:22:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [gd_esquema].[Cliente](
	[dni] [int] NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[direccion] [nvarchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
	[mail] [nvarchar](255) NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[es_discapacitado] [char](1) NULL,
	[sexo] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into dbo.Cliente (dni, nombre, apellido, direccion, telefono, mail, fecha_nacimiento)
(
	select distinct m.Cli_Dni as dni, m.Cli_Nombre as nombre, m.Cli_Apellido as apellido, 
			m.Cli_Dir as direccion, m.Cli_Telefono as telefono, m.Cli_Mail as mail,
			m.Cli_Fecha_Nac as fecha_nacimiento
	from gd_esquema.Maestra m
)