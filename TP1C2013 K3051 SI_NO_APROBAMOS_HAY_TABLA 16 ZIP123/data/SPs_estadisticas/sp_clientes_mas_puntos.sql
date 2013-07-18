CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_clientes_mas_puntos]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT TOP 5 p.dni, SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.fecha_otorgado BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END