CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_recorrido
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
		on r.id_ciudad_origen = cOrigen.id_ciudad and cOrigen.nombre = @p_ciudad_origen
	left join SI_NO_APROBAMOS_HAY_TABLA. Ciudad cDestino
		on r.id_ciudad_destino = cDestino.id_ciudad and cDestino.nombre = @p_ciudad_destino	
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on r.id_servicio = s.id_servicio 
	where ((@p_ciudad_origen IS NULL) OR (cOrigen.nombre like '%' + @p_ciudad_origen + '%'))
	and ((@p_ciudad_destino IS NULL) OR (cDestino.nombre like '%' + @p_ciudad_destino + '%'))
	and ((@p_tipo_servicio IS NULL) OR (@p_tipo_servicio like '%' + s.tipo_servicio + '%'))
END
