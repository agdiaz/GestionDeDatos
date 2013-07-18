

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_clientes_mas_puntos]
(
	@p_fecha_inicio datetime,
	@p_fecha_fin datetime
)
AS
BEGIN
	SELECT p.dni, SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.fecha_otorgado BETWEEN @p_fecha_inicio AND @p_fecha_fin
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END