CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_pasajes_cancelados_x_viaje int
	
	SELECT @cant_pasajes_cancelados_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] AS pasaje
	WHERE pasaje.id_viaje=@id_viaje
			AND pasaje.id_cancelacion IS NOT NULL
	
	RETURN @cant_pasajes_cancelados_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destinos_mas_cancelados_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) AS pasajes_cancelados
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] AS ciudad
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] AS recorrido
			ON ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
			ON viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) DESC
END
