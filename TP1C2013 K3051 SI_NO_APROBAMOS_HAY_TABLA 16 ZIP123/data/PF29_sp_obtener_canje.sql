CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_canje
	@p_id int
AS
BEGIN
	SELECT c.id_canje, c.dni, c.id_recompensa
	from SI_NO_APROBAMOS_HAY_TABLA.Canje c
	where c.id_canje = @p_id
END
GO
