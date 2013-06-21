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

COMMIT TRANSACTION comprasEncomiendas