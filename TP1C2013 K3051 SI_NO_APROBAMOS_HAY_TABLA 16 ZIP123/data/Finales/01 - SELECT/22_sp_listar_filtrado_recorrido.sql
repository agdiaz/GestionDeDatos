USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]    Script Date: 07/16/2013 02:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]
	@p_id_ciudad_origen int=NULL,
	@p_id_ciudad_destino int=NULL, 
	@p_id_servicio int=NULL
	AS
BEGIN
	SELECT distinct r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r 
	where ((@p_id_ciudad_origen IS NULL) OR (r.id_ciudad_origen = @p_id_ciudad_origen))
	and ((@p_id_ciudad_destino IS NULL) OR (r.id_ciudad_destino = @p_id_ciudad_destino))
	and ((@p_id_servicio IS NULL) OR ( r.id_servicio = @p_id_servicio))
	and r.baja = 0
END
