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