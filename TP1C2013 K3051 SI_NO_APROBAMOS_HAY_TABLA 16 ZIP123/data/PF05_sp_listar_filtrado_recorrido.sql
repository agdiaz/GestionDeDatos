CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_recorrido
	@p_ciudad_origen int = NULL,
	@p_ciudad_destino int = NULL, 
	@p_tipo_servicio int = NULL
	AS
BEGIN
	SELECT distinct r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
      ,r.[baja]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
	where ((@p_ciudad_origen IS NULL) OR (r.id_ciudad_origen = @p_ciudad_origen ))
	and ((@p_ciudad_destino IS NULL) OR (r.id_ciudad_destino = @p_ciudad_destino ))
	and ((@p_tipo_servicio IS NULL) OR (r.id_servicio = @p_tipo_servicio))
END
