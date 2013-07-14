USE [GD1C2013]
GO

/****** Object:  Index [indice_recorrido_ciudad]    Script Date: 07/14/2013 11:45:15 ******/
CREATE NONCLUSTERED INDEX [indice_recorrido_ciudad] ON [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] 
(
	[id_ciudad_destino] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


