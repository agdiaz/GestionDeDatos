
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje(
@p_fecha_salida datetime = NULL,
@p_fecha_llegada datetime = NULL,
@fecha_llegada_estimada datetime = NULL,
@p_micro int = NULL,
@p_recorrido numeric(18,2) = NULL 
)
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
	 FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
	where ((@p_fecha_salida IS NULL) OR (v.fecha_salida like '%' + @p_fecha_salida + '%'))
	and ((@p_fecha_llegada IS NULL) OR  (v.fecha_arribo like '%' + @p_fecha_llegada + '%' ))
	and ((@fecha_llegada_estimada IS NULL) OR (v.fecha_arribo_estimada like '%' + @fecha_llegada_estimada + '%' ))
	and ((@p_micro IS NULL) OR (v.id_micro like '%' + @p_micro + '%' ))
	and ((@p_recorrido IS NULL) OR (v.id_recorrido like '%' + @p_recorrido + '%' ))
END

