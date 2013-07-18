CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_puntos_por_cliente_detallado
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT p.dni,
	(p.puntos) as 'puntosOtorgados',
	(p.puntos_usados) as 'puntosUtilizados', 
	(p.puntos - p.puntos_usados) as 'puntosRestantes',
	(p.fecha_otorgado)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	ORDER BY p.fecha_otorgado ASC
END