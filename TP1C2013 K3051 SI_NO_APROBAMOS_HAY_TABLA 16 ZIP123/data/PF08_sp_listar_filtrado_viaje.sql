
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje
@p_fecha_salida datetime = NULL,
@p_fecha_llegada datetime = NULL,
@fecha_llegada_estimada datetime = NULL,
@p_micro int = NULL,
@p_recorrido numeric(18,2) = NULL 
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
      ,v.[baja]
	 FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
	where ((@p_fecha_salida IS NULL) OR (@p_fecha_salida = v.fecha_salida))
	and ((@p_fecha_llegada IS NULL) OR (@p_fecha_llegada = v.fecha_arribo))
	and ((@fecha_llegada_estimada IS NULL) OR (@fecha_llegada_estimada = v.fecha_arribo_estimada))
	and ((@p_micro IS NULL) OR (@p_micro = v.id_micro))
	and ((@p_recorrido IS NULL) OR (@p_recorrido = v.id_recorrido))
END

