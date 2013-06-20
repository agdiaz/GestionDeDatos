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
	[dni] [numeric](18, 0) NOT NULL,
	[username] [nvarchar](50) NOT NULL UNIQUE,
	[hash_password] [varbinary](32) NULL,
	[cant_intentos_fallidos] [int] NOT NULL,
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