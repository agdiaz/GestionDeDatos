ALTER PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_puntos_por_cliente]
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END