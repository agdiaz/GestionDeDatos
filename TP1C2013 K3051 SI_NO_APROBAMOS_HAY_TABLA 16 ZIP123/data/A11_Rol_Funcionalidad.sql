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
 CONSTRAINT [PK_Rol_funcionalidad_1] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


