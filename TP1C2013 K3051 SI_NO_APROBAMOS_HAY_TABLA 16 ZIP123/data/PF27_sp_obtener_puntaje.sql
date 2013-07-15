CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_puntaje
	@p_id int
AS
BEGIN
	SELECT p.id_puntaje, p.dni, p.id_compra, p.puntos, p.puntos_usados, p.fecha_otorgado
	from SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	where p.id_puntaje = @p_id
END
GO
