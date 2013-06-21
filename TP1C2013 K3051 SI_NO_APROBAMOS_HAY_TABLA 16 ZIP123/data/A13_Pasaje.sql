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

COMMIT TRANSACTION comprasPasajes
