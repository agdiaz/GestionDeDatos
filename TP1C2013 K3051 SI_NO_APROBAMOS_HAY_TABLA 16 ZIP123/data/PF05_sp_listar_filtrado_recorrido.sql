USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]    Script Date: 07/16/2013 02:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]
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
		on r.id_ciudad_origen = cOrigen.id_ciudad 
	left join SI_NO_APROBAMOS_HAY_TABLA. Ciudad cDestino
		on r.id_ciudad_destino = cDestino.id_ciudad 
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on r.id_servicio = s.id_servicio 
	where ((@p_ciudad_origen IS NULL) OR (cOrigen.nombre like '%' +  @p_ciudad_origen + '%'))
	and ((@p_ciudad_destino IS NULL) OR (cDestino.nombre like '%' +  @p_ciudad_destino + '%'))
	and ((@p_tipo_servicio IS NULL) OR ( s.tipo_servicio like '%' +  @p_tipo_servicio + '%'))
	and r.baja = 0
	and cOrigen.baja = 0
	and cDestino.baja = 0
END
