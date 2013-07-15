CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_recompensa
	@p_id int
AS
BEGIN
	SELECT r.id_recompensa, r.descripcion, r.puntos_costo, r.stock
	from SI_NO_APROBAMOS_HAY_TABLA.Recompensa r
	where r.id_recompensa = @p_id
END
GO
