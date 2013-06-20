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


