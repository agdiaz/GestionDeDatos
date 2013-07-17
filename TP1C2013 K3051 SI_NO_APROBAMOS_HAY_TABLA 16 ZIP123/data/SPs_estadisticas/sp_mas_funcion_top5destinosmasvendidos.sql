CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_mas_vendido_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) AS butacas_vendidas
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) desc
END

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje
(
	@id_viaje int
)
RETURNS int
BEGIN
	DECLARE @butacas_vendidas_x_viaje int
	SELECT @butacas_vendidas_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
		INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[pasaje] AS pasaje
			ON viaje.id_viaje=pasaje.id_viaje
	WHERE viaje.id_viaje=@id_viaje AND pasaje.id_cancelacion IS NULL
	RETURN @butacas_vendidas_x_viaje
END
